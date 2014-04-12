using System.Collections;
using UnityEditor;
using UnityEngine;

public class EditorHelper
{
	public static void MinMaxSerialized(string name, SerializedProperty spMin, SerializedProperty spMax, float minLimit, float maxLimit)
	{
		float min = spMin.floatValue;
		float max = spMax.floatValue;
		string lbl = name+" " + "["+min.ToString("0.0") +", "+ max.ToString("0.0")+"]";
		EditorGUILayout.MinMaxSlider(new GUIContent(lbl), ref min, ref max, minLimit, maxLimit);
		spMin.floatValue = min;
		spMax.floatValue = max;
	}
}
