using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class PlayerGroundedJumpTransition : SKState<PlayerModel>
{
	public override void begin()
	{
		
	}
	
	public override void reason()
	{
	}
	
	public override void update( float deltaTime )
	{
		// grab our current _context.velocity to use as a base for all calculations
		_context.velocity = _context.characterController2D.velocity;
		//start with no vertical speed
		_context.velocity.y = 0;
		
		if( _context.input.GetButton(InputButton.Right) )
		{
			_context.normalizedHorizontalSpeed = 1;
			_context.TryFlipVisual( true );
		}
		else if( _context.input.GetButton(InputButton.Left) )
		{
			_context.normalizedHorizontalSpeed = -1;
			_context.TryFlipVisual( false );
		}
		else
		{
			_context.normalizedHorizontalSpeed = 0;
		}

		//Jump
		_context.velocity.y = Mathf.Sqrt( 2f * _context.jumpHeight * -_context.gravity );
		_context.animator.Play( Animator.StringToHash( "Jump" ) );
		
		// apply horizontal speed smoothing it
		_context.velocity.x = Mathf.Lerp( _context.velocity.x, _context.normalizedHorizontalSpeed * _context.runSpeed, deltaTime * _context.inAirDamping );
		
		// apply gravity before moving
		_context.velocity.y += _context.gravity * deltaTime;
		
		_context.characterController2D.move( _context.velocity * deltaTime );


		//This is a transition so we immediately move to Air
		_machine.changeState<PlayerAirState>();
	}
	
	public override void end()
	{
		
	}
}