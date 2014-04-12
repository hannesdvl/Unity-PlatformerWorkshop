using UnityEngine;
using System.Collections;

public class Recyclable : MonoBehaviour
{
	public event System.Action<Recyclable> recycleEvent;
	public void Recycle()
	{
		if(this.gameObject.activeSelf)
		{
			recycleEvent(this);
		}
#if DEBUG_LEVEL_WARN
		else
		{
			D.warn("Calling recycle on inactive go "+name+", check if Recycle() is not being called twice!");
		}
#endif
	}
}