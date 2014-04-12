using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class PlayerGroundedState : SKState<PlayerModel>
{
	public override void begin()
	{
		
	}
	
	public override void reason()
	{
		if( _context.input.GetButtonDown(InputButton.Jump) )
		{
			_machine.changeState<PlayerGroundedJumpTransition>();
		}
		else if( !_context.characterController2D.isGrounded )
		{
			_machine.changeState<PlayerAirState>();
		}
	}
	
	public override void update( float deltaTime )
	{
		// grab our current _context.velocity to use as a base for all calculations
		_context.velocity = _context.characterController2D.velocity;
		// grounded means no vertical speed
		_context.velocity.y = 0;
		
		if( _context.input.GetButton(InputButton.Right) )
		{
			_context.normalizedHorizontalSpeed = 1;
			_context.TryFlipVisual( true );
			_context.animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( _context.input.GetButton(InputButton.Left) )
		{
			_context.normalizedHorizontalSpeed = -1;
			_context.TryFlipVisual( false );
			_context.animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			_context.normalizedHorizontalSpeed = 0;
			_context.animator.Play( Animator.StringToHash( "Idle" ) );
		}
		
		// apply horizontal speed smoothing it
		_context.velocity.x = Mathf.Lerp( _context.velocity.x, _context.normalizedHorizontalSpeed * _context.runSpeed, deltaTime * _context.groundDamping );
		
		// apply gravity before moving
		_context.velocity.y += _context.gravity * deltaTime;

		_context.characterController2D.move( _context.velocity * deltaTime );
	}
	
	public override void end()
	{
		
	}
}