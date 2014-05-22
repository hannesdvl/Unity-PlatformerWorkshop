using UnityEngine;
using System.Collections;

public class WrapAroundTrigger : MonoBehaviour
{
	float xMin, xMax, yMin, yMax;
	float width, height;

	void Awake()
	{

		width = transform.localScale.x;
		height = transform.localScale.y;
		xMin = transform.position.x;
		xMax = xMin + width;
		yMin = transform.position.y;
		yMax = yMin + height;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.position.y < yMin) other.transform.SetY(other.transform.position.y + height);
		if(other.transform.position.y > yMax) other.transform.SetY(other.transform.position.y - height);
		if(other.transform.position.x < xMin) other.transform.SetX(other.transform.position.x + width);
		if(other.transform.position.x > xMax) other.transform.SetX(other.transform.position.x - width);
	}
}
