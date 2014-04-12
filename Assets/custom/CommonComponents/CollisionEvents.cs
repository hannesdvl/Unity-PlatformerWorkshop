using UnityEngine;
using System.Collections;

public class CollisionEvents : MonoBehaviour
{
	public event System.Action<Collision> onCollisionEnter = delegate {};
	public event System.Action<Collision> onCollisionExit = delegate {};
	
	void OnCollisionEnter(Collision collision)
	{
		onCollisionEnter(collision);
	}

	void OnCollisionExit(Collision collision)
	{
		onCollisionExit(collision);
	}
}
