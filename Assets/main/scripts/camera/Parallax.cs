using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	[Range(0.0f,1.0f)]
	public float factor = 0.5f;

	void Update()
	{
		Vector3 plxPos = Camera.main.transform.position * factor;
		transform.position = new Vector3 (plxPos.x, 0, 0);
	}
}