using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReadData : MonoBehaviour
{
	public string url = "http://hannesdeville.be/dev/pixelwall/webservice.php";

	public event Action<int[]> onReadComplete = delegate{};

	bool _reading;

	void Awake()
	{
		_reading = false;
	}

	/*
	void OnGUI()
	{
		if(string.IsNullOrEmpty(_data))
		{
			if (!_reading && GUILayout.Button ("READ"))
			{
				StartCoroutine("ReadDataCR");
			}
		}
		else
		{
			GUILayout.Label(_data);
		}
	}
	*/

	public void StartRead()
	{
		StartCoroutine("ReadDataCR");
	}

	IEnumerator ReadDataCR()
	{
		_reading = true;
		WWW www = new WWW (url);
		yield return www;

		List<int> data = new List<int>();
		Debug.Log (www.text);
		int result = 0;
		for (int i = 0; i < www.text.Length; i++)
		{
			if( int.TryParse(www.text[i].ToString(), out result) )
			{
				data.Add( result );
			}

		}

		_reading = false;
		onReadComplete (data.ToArray ());
	}
}