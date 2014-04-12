using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour
{
	public float gravity = -15f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	
	[HideInInspector]
	public CharacterController2D characterController2D;
	[HideInInspector]
	public AbstractInput input;
	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public float normalizedHorizontalSpeed = 0;
	[HideInInspector]
	public Animator animator;
	[HideInInspector]
	public bool facingRight;

	void Awake()
	{
		animator = GetComponent<Animator>();
		characterController2D = GetComponent<CharacterController2D>();
		characterController2D.onControllerCollidedEvent += onControllerCollider;
		input = GetComponent<AbstractInput> ();
	}

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits
		if( hit.normal.y == 1f )
			return;
		
		// logs any collider hits if uncommented
//		Debug.Log( "flags: " + characterController2D.collisionState + ", hit.normal: " + hit.normal );
	}

	public void TryFlipVisual( bool toRight )
	{
		facingRight = toRight;
		if( (toRight && transform.localScale.x < 0f) || (!toRight && transform.localScale.x > 0f) )
		{
			transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
	}
}
