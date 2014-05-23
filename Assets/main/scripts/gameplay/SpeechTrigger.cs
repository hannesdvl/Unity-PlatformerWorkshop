using UnityEngine;
using System.Collections;

public class SpeechTrigger : MonoBehaviour
{
	public SpriteRenderer speechBubble;
	public TextMesh textMesh;
	public string text = "";
	public Transform fetch;
	public string afterFetch = "";
	public int lineLenth = 25;
	public Transform target;

	string _text;
	GoTween _twnEnter;
	GoTween _twnExit;
	Vector3 _originalScale;

	void Awake()
	{
		text = ResolveTextSize (text, lineLenth);
		afterFetch = ResolveTextSize (afterFetch, lineLenth);
		_text = text;

		_originalScale = speechBubble.transform.localScale;
		speechBubble.enabled = false;
		textMesh.text = "";

		_twnExit = new GoTween (speechBubble.transform, 0.15f, new GoTweenConfig ().scale (_originalScale*0.001f).setEaseType(GoEaseType.ExpoOut).onComplete(OnExitComplete));
		speechBubble.transform.localScale = _originalScale * 0.001f;
		_twnEnter = new GoTween (speechBubble.transform, 0.15f, new GoTweenConfig ().scale (_originalScale).setEaseType(GoEaseType.BackOut).onComplete(OnEnterComplete));

		_twnEnter.pause ();
		_twnExit.pause ();
		_twnEnter.autoRemoveOnComplete = false;
		_twnExit.autoRemoveOnComplete = false;
		Go.addTween (_twnEnter);
		Go.addTween (_twnExit);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Transform fetchObj = (other.transform.childCount > 0) ? other.transform.GetChild(0) : null;
		if(fetchObj == fetch)
		{
			_text = afterFetch;
			fetchObj.parent = target;
			fetchObj.position = target.position;
			fetchObj.collider2D.enabled = false;

			StartSpeech();
		}

		else if (other.CompareTag ("Player"))
		{
			StartSpeech();
		}
	}

	void StartSpeech()
	{
		if(!speechBubble.enabled)
		{
			StopCoroutine("SpeechHideCR");
			_twnExit.pause();
			_twnEnter.restart();
			speechBubble.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
		{
			StartCoroutine("SpeechHideCR");
		}
	}

	void OnEnterComplete(AbstractGoTween tween)
	{
		textMesh.text = _text;
	}

	void OnExitComplete(AbstractGoTween tween)
	{
		speechBubble.enabled = false;
	}

	IEnumerator SpeechHideCR()
	{
		yield return new WaitForSeconds (0.5f);
		_twnEnter.pause();
		_twnExit.restart();
		textMesh.text = "";
	}

	string ResolveTextSize(string input, int lineLength)
	{
		string[] words = input.Split(" "[0]);
		string result = "";
		string line = "";  
		foreach(string s in words)
		{
			string temp = line + " " + s;
			if(temp.Length > lineLength)
			{
				result += line + "\n";
				line = s;
			}
			else
			{
				line = temp;
			}
		}  
		result += line;
		return result.Substring(1,result.Length-1);
	}
}
