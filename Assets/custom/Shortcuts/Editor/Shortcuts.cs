using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shortcuts : Editor
{
	/// <summary>
	/// Adds an empty GameObject as a child of each selected object or to the root of the scene
	/// Resets local position, scale & rotation
	/// Selects created object(s)
	/// Based on: http://wiki.unity3d.com/index.php/AddChild
	/// </summary>
	[MenuItem ("Edit/AddChild %e")]
	static void MenuAddChild()
	{
		try
		{
			Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
			List<GameObject> newSelection = new List<GameObject>();
			if(transforms.Length > 0)
			{
				foreach(Transform transform in transforms) newSelection.Add( CreateEmptyGameObject(transform) );
			}
			else
			{
				newSelection.Add( CreateEmptyGameObject() );
			}
			Selection.objects = newSelection.ToArray();
		}
		catch (Exception ex)
		{
			Debug.LogWarning("AddChild Failed: "+ex.Message);
		}
	}

	static GameObject CreateEmptyGameObject(Transform parent = null)
	{
		GameObject newChild = new GameObject("_null");
		Undo.RegisterCreatedObjectUndo (newChild, "Created GameObject _null");
		if(parent != null) newChild.transform.parent = parent;

		newChild.transform.localPosition = Vector3.zero;
		newChild.transform.localScale = Vector3.one;
		newChild.transform.localRotation = Quaternion.identity;

		return newChild;
	}
}