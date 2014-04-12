using UnityEngine;
using System.Collections;

public class Collision2DEvents : MonoBehaviour
{
	public event System.Action<Collision2D> onCollisionEnter2D = delegate {};
	public event System.Action<Collision2D> onCollisionExit2D = delegate {};
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		onCollisionEnter2D(collision);
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		onCollisionExit2D(collision);
	}
}
