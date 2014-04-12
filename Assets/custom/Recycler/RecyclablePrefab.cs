using System;
using UnityEngine;

[Serializable]
public class RecyclablePrefab
{
	public Recyclable prefab;
	public int poolSize;
	public Transform parent;
	ObjectRecycler _recycler;
	
	public void Create()
	{
		_recycler = new ObjectRecycler( prefab.gameObject, poolSize, parent );
	}
	
	public GameObject GetNextFree()
	{
		GameObject item = _recycler.nextFree;
		if(item)
		{
			item.GetComponent<Recyclable>().recycleEvent -= HandleRecycle;
			item.GetComponent<Recyclable>().recycleEvent += HandleRecycle;
		}
		return item;
	}
	
	void HandleRecycle (Recyclable recyclable)
	{
		recyclable.recycleEvent -= HandleRecycle;
		_recycler.freeObject(recyclable.gameObject);
	}
}