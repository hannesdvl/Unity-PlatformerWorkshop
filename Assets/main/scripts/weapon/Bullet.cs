using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	Recyclable _recyclable;

	void Awake()
	{
		_recyclable = GetComponent<Recyclable> ();
	}

	public void Fire(Vector2 force)
	{
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce (force);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		_recyclable.Recycle ();
	}
}