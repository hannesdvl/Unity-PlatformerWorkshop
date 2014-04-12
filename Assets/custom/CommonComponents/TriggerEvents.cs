using UnityEngine;
using System.Collections;

public class TriggerEvents : MonoBehaviour
{
	public event System.Action<Collider> onTriggerEnter = delegate {};
	public event System.Action<Collider> onTriggerExit = delegate {};
	
	void OnTriggerEnter(Collider other)
	{
		onTriggerEnter(other);
	}
	
	void OnTriggerExit(Collider other)
	{
		onTriggerExit(other);
	}
}