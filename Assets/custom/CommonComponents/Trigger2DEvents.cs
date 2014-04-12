using UnityEngine;
using System.Collections;

public class Trigger2DEvents : MonoBehaviour
{
	public event System.Action<Collider2D> onTriggerEnter2D = delegate {};
	public event System.Action<Collider2D> onTriggerExit2D = delegate {};
	
	void OnTriggerEnter2D(Collider2D other)
	{
		onTriggerEnter2D(other);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		onTriggerExit2D(other);
	}
}
