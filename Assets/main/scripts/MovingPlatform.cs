using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
	public float leftPosition;
	public float rightPosition;
	public float speed = 1.0f;

	void Update()
	{
		transform.Translate (speed * Time.deltaTime, 0, 0);

		// cehck if we reached the left or right limit
		if (transform.position.x >= rightPosition || transform.position.x <= leftPosition)
		{
			//EN: change moving direction
			//NL: verander van richting
			speed = -speed;
		}
	}

	IEnumerator MoveCR()
	{
		while (true)
		{

		}
	}
}