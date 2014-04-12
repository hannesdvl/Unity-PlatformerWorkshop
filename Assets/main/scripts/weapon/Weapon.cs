using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public RecyclablePrefab bullets;
	public float power = 10.0f;

	PlayerModel _playerModel;

	void Awake()
	{
		bullets.Create ();
	}

	void OnEnable()
	{
		_playerModel = (transform.parent != null) ? transform.parent.GetComponent<PlayerModel> () : null;
		if (_playerModel == null)
		{
			Debug.LogWarning("Weapon must be the child of a Player!");
			this.enabled = false;
		}
	}

	void OnDisable()
	{
	}

	void Update ()
	{
		if (_playerModel.input.GetButtonDown (InputButton.Action))
		{
			GameObject go = bullets.GetNextFree();
			go.SetActive(true);
			Bullet bullet = go.GetComponent<Bullet>();

			float playerDir = _playerModel.facingRight ? 1f : -1f;

			go.transform.position = transform.position + new Vector3(playerDir,0,0);
			Vector2 force = new Vector2(playerDir * power,0);

			bullet.Fire(force);
		}
	}
}
