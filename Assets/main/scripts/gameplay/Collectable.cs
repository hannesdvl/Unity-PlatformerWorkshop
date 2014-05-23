using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
			Vector3 lclScale = transform.localScale;
			transform.parent = other.transform;
			transform.position = other.transform.position;
			transform.localScale = lclScale;
		}
	}
}
