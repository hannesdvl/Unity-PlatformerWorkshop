using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

public static class ExtensionMethods
{
	/* List<T> */
	
	public static void Shuffle<T>(this List<T> list) 
	{
		System.Random rng = new System.Random();
		int n = list.Count;
		
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
	
	/* Enum */
	private static void CheckIsEnum<T>(bool withFlags)
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException(string.Format("Type '{0}' is not an enum", typeof(T).FullName));
        if (withFlags && !Attribute.IsDefined(typeof(T), typeof(FlagsAttribute)))
            throw new ArgumentException(string.Format("Type '{0}' doesn't have the 'Flags' attribute", typeof(T).FullName));
    }

    public static bool IsFlagSet<T>(this T value, T flag) where T : struct
    {
        CheckIsEnum<T>(true);
        long lValue = Convert.ToInt64(value);
        long lFlag = Convert.ToInt64(flag);
        return (lValue & lFlag) != 0;
    }

    public static IEnumerable<T> GetFlags<T>(this T value) where T : struct
    {
        CheckIsEnum<T>(true);
        foreach (T flag in Enum.GetValues(typeof(T)).Cast<T>())
        {
            if (value.IsFlagSet(flag))
                yield return flag;
        }
    }

    public static T SetFlags<T>(this T value, T flags, bool on) where T : struct
    {
        CheckIsEnum<T>(true);
        long lValue = Convert.ToInt64(value);
        long lFlag = Convert.ToInt64(flags);
        if (on)
        {
            lValue |= lFlag;
        }
        else
        {
            lValue &= (~lFlag);
        }
        return (T)Enum.ToObject(typeof(T), lValue);
    }

    public static T SetFlags<T>(this T value, T flags) where T : struct
    {
        return value.SetFlags(flags, true);
    }

    public static T ClearFlags<T>(this T value, T flags) where T : struct
    {
        return value.SetFlags(flags, false);
    }

    public static T CombineFlags<T>(this IEnumerable<T> flags) where T : struct
    {
        CheckIsEnum<T>(true);
        long lValue = 0;
        foreach (T flag in flags)
        {
            long lFlag = Convert.ToInt64(flag);
            lValue |= lFlag;
        }
        return (T)Enum.ToObject(typeof(T), lValue);
    }

    public static string GetDescription<T>(this T value) where T : struct
    {
        CheckIsEnum<T>(false);
        string name = Enum.GetName(typeof(T), value);
        if (name != null)
        {
            FieldInfo field = typeof(T).GetField(name);
            if (field != null)
            {
                DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        return null;
    }
	
	/* UnityEngine.Transform */
	
	public static void SetX(this Transform t, float x) { t.position = new Vector3(x, t.position.y, t.position.z); }
	public static void SetY(this Transform t, float y) { t.position = new Vector3(t.position.x, y, t.position.z); }
	public static void SetZ(this Transform t, float z) { t.position = new Vector3(t.position.x, t.position.y, z); }
	public static void SetLocalX(this Transform t, float x) { t.localPosition = new Vector3(x, t.localPosition.y, t.localPosition.z); }
	public static void SetLocalY(this Transform t, float y) { t.localPosition = new Vector3(t.localPosition.x, y, t.localPosition.z); }
	public static void SetLocalZ(this Transform t, float z) { t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y, z); }
	
	public static void SetEulerX(this Transform t, float x) { t.rotation = Quaternion.Euler(x, t.rotation.eulerAngles.y, t.rotation.eulerAngles.z); }
	public static void SetEulerY(this Transform t, float y) { t.rotation = Quaternion.Euler(t.rotation.eulerAngles.x, y, t.rotation.eulerAngles.z); }
	public static void SetEulerZ(this Transform t, float z) { t.rotation = Quaternion.Euler(t.rotation.eulerAngles.x, t.rotation.eulerAngles.y, z); }
	public static void SetLocalEulerX(this Transform t, float x) { t.localRotation = Quaternion.Euler(x, t.localRotation.eulerAngles.y, t.localRotation.eulerAngles.z); }
	public static void SetLocalEulerY(this Transform t, float y) { t.localRotation = Quaternion.Euler(t.localRotation.eulerAngles.x, y, t.localRotation.eulerAngles.z); }
	public static void SetLocalEulerZ(this Transform t, float z) { t.localRotation = Quaternion.Euler(t.localRotation.eulerAngles.x, t.localRotation.eulerAngles.y, z); }
	
	public static void SetLocalScaleX(this Transform t, float x) { t.localScale = new Vector3(x, t.localScale.y, t.localScale.z); }
	public static void SetLocalScaleY(this Transform t, float y) { t.localScale = new Vector3(t.localScale.x, y, t.localScale.z); }
	public static void SetLocalScaleZ(this Transform t, float z) { t.localScale = new Vector3(t.localScale.x, t.localScale.y, z); }
	
	/* UnityEngine.ParticleSystem */
	
	public static void Prewarm(this ParticleSystem ps)
	{
		ps.Simulate(0.01f,true);
		ps.Stop();
		ps.Clear();
	}
	
    /// <summary>
    /// Gets the components in children.
    /// </summary>
    /// <param name='skipChildren'>
    /// How many child levels deep to select from
    /// </param>
	public static T[] GetComponentsInChildren<T>(this Transform transform, int skipChildren, bool includeInactive = false) where T : UnityEngine.Component
    {
	    if (skipChildren == 0)
			return transform.GetComponentsInChildren<T>(includeInactive);
		
		skipChildren--;
	    return transform.Cast<Transform>().SelectMany( child => child.GetComponentsInChildren<T>(skipChildren, includeInactive) ).ToArray();
    }
	
	/* Others */
	
	public static IEnumerator Play( this Animation animation, bool ignoreTimeScale)
	{
		return animation.Play( animation.clip.name, ignoreTimeScale, null);
	}
	
	public static IEnumerator Play( this Animation animation, string clipName, bool ignoreTimeScale, Action onComplete )
	{
		if(ignoreTimeScale)
		{
			AnimationState _currState = animation[clipName];
			bool isPlaying = true;
			float _progressTime = 0F;
			float _timeAtLastFrame = 0F;
			float _timeAtCurrentFrame = 0F;
			float deltaTime = 0F;
			
			animation.Play(clipName);
			 
			_timeAtLastFrame = Time.realtimeSinceStartup;
			while (isPlaying)
			{
				_timeAtCurrentFrame = Time.realtimeSinceStartup;
				deltaTime = _timeAtCurrentFrame - _timeAtLastFrame;
				_timeAtLastFrame = _timeAtCurrentFrame;
				 
				_progressTime += deltaTime;
				_currState.normalizedTime = _progressTime / _currState.length;
				animation.Sample ();
					
				if (_progressTime >= _currState.length)
				{
					if(_currState.wrapMode != WrapMode.Loop) { isPlaying = false; }
					else { _progressTime = 0.0f; }
				}
				 
				yield return new WaitForEndOfFrame();
			}
			yield return null;
			if(onComplete != null)
			{
				onComplete();
			}
		}
		else
		{
			animation.Play(clipName);
		}
	}
}