using UnityEngine;
using System.Collections;

public class LeftRightWalker : MonoBehaviour
{
	public float walkDuration = 1.0f;

	SimulateInput _simulateInput;
	bool _isLeft;

	void Awake()
	{
		_simulateInput = GetComponent<SimulateInput> ();
	}

	void Start ()
	{
		StartCoroutine ("WalkLeftRightCR");
	}

	IEnumerator WalkLeftRightCR()
	{
		while (true)
		{
			yield return new WaitForSeconds(walkDuration);
			if(_isLeft)
			{
				_simulateInput.ReleaseButton(InputButton.Right);
				_simulateInput.PressButton(InputButton.Left);
			}
			else
			{
				_simulateInput.ReleaseButton(InputButton.Left);
				_simulateInput.PressButton(InputButton.Right);
			}
			_isLeft = !_isLeft;
		}
	}
}
