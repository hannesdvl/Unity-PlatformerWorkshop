using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour
{
	public GridPlace gridPlace;
	public ReadData readData;

	void Start()
	{
		readData.onReadComplete += OnReadComplete;
		readData.StartRead ();
	}

	void OnReadComplete(int[] data)
	{
		gridPlace.Setup(data);
	}
}
