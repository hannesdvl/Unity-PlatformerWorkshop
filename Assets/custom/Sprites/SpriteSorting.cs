using UnityEngine;
using System.Collections;

public class SpriteSorting : MonoBehaviour
{
	public string sortingLayerName = "Default";
	public int sortingOrder;

	void OnEnable()
	{
		ApplySorting();
	}

	public void ApplySorting()
	{
		this.renderer.sortingLayerName = sortingLayerName;
		this.renderer.sortingOrder = sortingOrder;
	}
}
