using UnityEngine;
using System.Collections;

public class BulletPhysics : Bullet
{
	Recyclable _recyclable;
	
	void Awake()
	{
		_recyclable = GetComponent<Recyclable> ();
	}
	
	public override void Fire(Vector2 force)
	{
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (force);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		_recyclable.Recycle ();
	}
}