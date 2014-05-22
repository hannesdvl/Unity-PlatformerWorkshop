using UnityEngine;
using System.Collections;

public class GridPlace : MonoBehaviour
{
	public enum FillType { A, B, None }

	public float tileSize;
	public int nRows;
	public int nColumns;

	public RecyclablePrefab prefabA;
	public RecyclablePrefab prefabB;
	public FillType[] fillTypes;

	void Awake()
	{
		prefabA.Create ();
		prefabB.Create ();
	}

	public void Setup(int[] data)
	{
		Debug.Log ("SETUP!");
		int max = data.Length;
		for (int i = 0; i < max; i++)
		{
			float x = i % nColumns * tileSize;
			float y = (i / nRows) * tileSize;
			Vector2 pos = new Vector2( x, y );
			PlaceFill( fillTypes[data[i]], pos );
		}
	}
	
	void PlaceFill( FillType fillType, Vector2 position )
	{
		GameObject go = null;
		switch (fillType)
		{
		case FillType.A: go = prefabA.GetNextFree(); break;
		case FillType.B: go = prefabB.GetNextFree(); break;
		default:break;
		}

		if (go != null)
		{
			go.SetActive(true);
			go.transform.position = position;
		}
	}

}