using UnityEngine;
using System.Collections;

public class SmoothFollowCamera : MonoBehaviour
{
	public Transform target;
	public float smoothTime = .05f;
	Vector3 _velocity;

	CharacterController2D _playerController;

	void LateUpdate ()
	{
		Vector3 targetPos = new Vector3( target.position.x, target.position.y, transform.position.z);
		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref _velocity, smoothTime);
	}
}
