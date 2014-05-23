using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
			transform.position = other.transform.position;
			transform.parent = other.transform;
		}
	}
}
