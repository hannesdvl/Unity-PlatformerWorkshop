using UnityEngine;
using System.Collections;

public class BulletRay : Bullet
{
	public float speed = 1.0f;

	Recyclable _recyclable;
	Vector2 _direction;

	void Awake()
	{
		_recyclable = GetComponent<Recyclable> ();
	}

	void OnEnable()
	{

	}

	void OnDisable()
	{

	}
	
	public override void Fire(Vector2 force)
	{
		_direction = force;
	}

	void Update()
	{
		Vector2 moveVect = _direction.normalized * speed * Time.deltaTime;

		RaycastHit2D hit = Physics2D.Raycast (transform.position, moveVect, moveVect.magnitude);
		if (hit.collider != null)
		{
			Debug.Log( "hit: "+hit.collider, hit.collider.gameObject);
			//impact
			transform.position = hit.point;
			_recyclable.Recycle ();
		}
		else
		{
			transform.Translate (moveVect);
		}
	}
}
