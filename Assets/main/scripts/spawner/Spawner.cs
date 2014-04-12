using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public RecyclablePrefab prefabs;
	public float spawnRate = 1.0f;

	void Awake()
	{
		prefabs.Create ();
	}

	void OnEnable()
	{
		StartCoroutine ("SpawnCR");
	}

	void OnDisable()
	{
		StopCoroutine ("SpawnCR");
	}

	IEnumerator SpawnCR()
	{
		while (true)
		{
			yield return new WaitForSeconds (spawnRate);
			GameObject go = prefabs.GetNextFree ();
			if (go != null)
			{
					go.SetActive (true);
					go.transform.position = transform.position;
			}
		}
	}
}
