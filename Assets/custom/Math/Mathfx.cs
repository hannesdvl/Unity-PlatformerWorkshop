/// <summary>
/// Offers Lerp alternatives
/// based on http://wiki.unity3d.com/index.php?title=Mathfx
/// </summary>

using UnityEngine;
using System;

public class Mathfx
{
	public enum LerpType
	{
		Linear,
		Hermite,
		Sinerp,
		Coserp,
		Clerp,
		Berp,
		EaseInQuad,
		EaseOutQuad,
		EaseInOutQuad,
		EaseInCubic,
		EaseOutCubic,
		EaseInOutCubic,
		EaseInQuart,
		EaseOutQuart,
		EaseInOutQuart,
		EaseInQuint,
		EaseOutQuint,
		EaseInOutQuint,
		EaseInSine,
		EaseOutSine,
		EaseInOutSine,
		EaseInExpo,
		EaseOutExpo,
		EaseInOutExpo,
		EaseInCirc,
		EaseOutCirc,
		EaseInOutCirc,
		Spring,
		EaseInBounce,
		EaseOutBounce,
		EaseInOutBounce,
		EaseInBack,
		EaseOutBack,
		EaseInOutBack,
		EaseInElastic,
		EaseOutElastic,
		EaseInOutElastic
	}
	
	/// <summary>
	/// This method will interpolate while easing in and out at the limits.
	/// </summary>
    public static float Hermite(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
    }
	
	/// <summary>
	/// Short for 'sinusoidal interpolation', this method will interpolate while easing around the end, when value is near one.
	/// </summary>
    public static float Sinerp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, Mathf.Sin(value * Mathf.PI * 0.5f));
    }
	
	/// <summary>
	/// Similar to Sinerp, except it eases in, when value is near zero, instead of easing out (and uses cosine instead of sine).
	/// </summary>
    public static float Coserp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(value * Mathf.PI * 0.5f));
    }
	
	/// <summary>
	/// Short for 'boing-like interpolation', this method will first overshoot, then waver back and forth around the end value before coming to a rest.
	/// </summary>
	public static float Berp(float start, float end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        return start + (end - start) * value;
    }
 
	/// <summary>
	/// Works like Lerp, but has ease-in and ease-out of the values.
	/// </summary>
    public static float SmoothStep(float x, float min, float max) 
    {
        x = Mathf.Clamp (x, min, max);
        float v1 = (x-min)/(max-min);
        float v2 = (x-min)/(max-min);
        return -2*v1 * v1 *v1 + 3*v2 * v2;
    }
	
	/// <summary>
	/// 
	/// </summary>
    public static float Lerp(float start, float end, float value)
    {
        return ((1.0f - value) * start) + (value * end);
    }
	
	public static float Lerp(float start, float end, float value, LerpType lerpType)
    {
		switch (lerpType)
		{
		case LerpType.Linear: return Lerp(start,end,value);
		case LerpType.Hermite: return Hermite(start,end,value);
		case LerpType.Sinerp: return Sinerp(start,end,value);
		case LerpType.Coserp: return Coserp(start,end,value);
		case LerpType.Clerp: return Clerp(start,end,value);
		case LerpType.Berp: return Berp(start,end,value);
		case LerpType.EaseInQuad: return EaseInQuad(start,end,value);
		case LerpType.EaseOutQuad: return EaseOutQuad(start,end,value);
		case LerpType.EaseInOutQuad: return EaseInOutQuad(start,end,value);
		case LerpType.EaseInCubic: return EaseInCubic(start,end,value);
		case LerpType.EaseOutCubic: return EaseOutCubic(start,end,value);
		case LerpType.EaseInOutCubic: return EaseInOutCubic(start,end,value);
		case LerpType.EaseInQuart: return EaseInQuart(start,end,value);
		case LerpType.EaseOutQuart: return EaseOutQuart(start,end,value);
		case LerpType.EaseInOutQuart: return EaseInOutQuart(start,end,value);
		case LerpType.EaseInQuint: return EaseInQuint(start,end,value);
		case LerpType.EaseOutQuint: return EaseOutQuint(start,end,value);
		case LerpType.EaseInOutQuint: return EaseInOutQuint(start,end,value);
		case LerpType.EaseInSine: return EaseInSine(start,end,value);
		case LerpType.EaseOutSine: return EaseOutSine(start,end,value);
		case LerpType.EaseInOutSine: return EaseInOutSine(start,end,value);
		case LerpType.EaseInExpo: return EaseInExpo(start,end,value);
		case LerpType.EaseOutExpo: return EaseOutExpo(start,end,value);
		case LerpType.EaseInOutExpo: return EaseInOutExpo(start,end,value);
		case LerpType.EaseInCirc: return EaseInCirc(start,end,value);
		case LerpType.EaseOutCirc: return EaseOutCirc(start,end,value);
		case LerpType.EaseInOutCirc: return EaseInOutCirc(start,end,value);
		case LerpType.Spring: return Spring(start,end,value);
		case LerpType.EaseInBounce: return EaseInBounce(start,end,value);
		case LerpType.EaseOutBounce: return EaseOutBounce(start,end,value);
		case LerpType.EaseInOutBounce: return EaseInOutBounce(start,end,value);
		case LerpType.EaseInBack: return EaseInBack(start,end,value);
		case LerpType.EaseOutBack: return EaseOutBack(start,end,value);
		case LerpType.EaseInOutBack: return EaseInOutBack(start,end,value);
		case LerpType.EaseInElastic: return EaseInElastic(start,end,value);
		case LerpType.EaseOutElastic: return EaseOutElastic(start,end,value);
		case LerpType.EaseInOutElastic: return EaseInOutElastic(start,end,value);
		}
		return 0;
    }
 
	/// <summary>
	/// Will return the nearest point on a line to a point. Useful for making an object follow a track.
	/// </summary>
    public static Vector3 NearestPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        Vector3 lineDirection = Vector3.Normalize(lineEnd-lineStart);
        float closestPoint = Vector3.Dot((point-lineStart),lineDirection)/Vector3.Dot(lineDirection,lineDirection);
        return lineStart+(closestPoint*lineDirection);
    }
 
	/// <summary>
	/// Works like NearestPoint except the end of the line is clamped.
	/// </summary>
    public static Vector3 NearestPointStrict(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
    {
        Vector3 fullDirection = lineEnd-lineStart;
        Vector3 lineDirection = Vector3.Normalize(fullDirection);
        float closestPoint = Vector3.Dot((point-lineStart),lineDirection)/Vector3.Dot(lineDirection,lineDirection);
        return lineStart+(Mathf.Clamp(closestPoint,0.0f,Vector3.Magnitude(fullDirection))*lineDirection);
    }
	
	/// <summary>
	/// 
	/// </summary>
    public static float Bounce(float x)
	{
		return Mathf.Abs(Mathf.Sin(6.28f*(x+1f)*(x+1f)) * (1f-x));
    }
	
	/// <summary>
	/// test for value that is near specified float (due to floating point inprecision)
	/// </summary>
    public static bool Approx(float val, float about, float range)
	{
		return ( ( Mathf.Abs(val - about) < range) );
    }
	
	/// <summary>
	/// test if a Vector3 is close to another Vector3 (due to floating point inprecision)
    /// compares the square of the distance to the square of the range as this 
    /// avoids calculating a square root which is much slower than squaring the range
	/// </summary>
    public static bool Approx(Vector3 val, Vector3 about, float range)
	{
        return ( (val - about).sqrMagnitude < range*range);
    }
	
	/// <summary>
	/// CLerp - Circular Lerp - is like lerp but handles the wraparound from 0 to 360.
	/// This is useful when interpolating eulerAngles and the object
	/// crosses the 0/360 boundary.  The standard Lerp function causes the object
	/// to rotate in the wrong direction and looks stupid. Clerp fixes that.
	/// </summary>
    public static float Clerp(float start , float end, float value)
	{
        float min = 0.0f;
        float max = 360.0f;
        float half = Mathf.Abs((max - min)/2.0f);//half the distance between min and max
        float retval = 0.0f;
        float diff = 0.0f;
        if((end - start) < -half)
		{
            diff = ((max - start)+end)*value;
			retval =  start+diff;
        }
        else if((end - start) > half)
		{
            diff = -((max - end)+start)*value;
            retval =  start+diff;
        }
        else retval =  start+(end-start)*value;
		return retval;
    }
	
	#region Easing Curves imported from iTween
	public static float Spring(float start, float end, float value){
		value = Mathf.Clamp01(value);
		value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
		return start + (end - start) * value;
	}

	public static float EaseInQuad(float start, float end, float value){
		end -= start;
		return end * value * value + start;
	}

	public static float EaseOutQuad(float start, float end, float value){
		end -= start;
		return -end * value * (value - 2) + start;
	}

	public static float EaseInOutQuad(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value + start;
		value--;
		return -end / 2 * (value * (value - 2) - 1) + start;
	}

	public static float EaseInCubic(float start, float end, float value){
		end -= start;
		return end * value * value * value + start;
	}

	public static float EaseOutCubic(float start, float end, float value){
		value--;
		end -= start;
		return end * (value * value * value + 1) + start;
	}

	public static float EaseInOutCubic(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value + start;
		value -= 2;
		return end / 2 * (value * value * value + 2) + start;
	}

	public static float EaseInQuart(float start, float end, float value){
		end -= start;
		return end * value * value * value * value + start;
	}

	public static float EaseOutQuart(float start, float end, float value){
		value--;
		end -= start;
		return -end * (value * value * value * value - 1) + start;
	}

	public static float EaseInOutQuart(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value * value + start;
		value -= 2;
		return -end / 2 * (value * value * value * value - 2) + start;
	}

	public static float EaseInQuint(float start, float end, float value){
		end -= start;
		return end * value * value * value * value * value + start;
	}

	public static float EaseOutQuint(float start, float end, float value){
		value--;
		end -= start;
		return end * (value * value * value * value * value + 1) + start;
	}

	public static float EaseInOutQuint(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value * value * value + start;
		value -= 2;
		return end / 2 * (value * value * value * value * value + 2) + start;
	}

	public static float EaseInSine(float start, float end, float value){
		end -= start;
		return -end * Mathf.Cos(value / 1 * (Mathf.PI / 2)) + end + start;
	}

	public static float EaseOutSine(float start, float end, float value){
		end -= start;
		return end * Mathf.Sin(value / 1 * (Mathf.PI / 2)) + start;
	}

	public static float EaseInOutSine(float start, float end, float value){
		end -= start;
		return -end / 2 * (Mathf.Cos(Mathf.PI * value / 1) - 1) + start;
	}

	public static float EaseInExpo(float start, float end, float value){
		end -= start;
		return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
	}

	public static float EaseOutExpo(float start, float end, float value){
		end -= start;
		return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
	}

	public static float EaseInOutExpo(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
		value--;
		return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
	}

	public static float EaseInCirc(float start, float end, float value){
		end -= start;
		return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
	}

	public static float EaseOutCirc(float start, float end, float value){
		value--;
		end -= start;
		return end * Mathf.Sqrt(1 - value * value) + start;
	}

	public static float EaseInOutCirc(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return -end / 2 * (Mathf.Sqrt(1 - value * value) - 1) + start;
		value -= 2;
		return end / 2 * (Mathf.Sqrt(1 - value * value) + 1) + start;
	}
	
	public static float EaseInBounce(float start, float end, float value){
		end -= start;
		float d = 1f;
		return end - EaseOutBounce(0, end, d-value) + start;
	}
	
	public static float EaseOutBounce(float start, float end, float value){
		value /= 1f;
		end -= start;
		if (value < (1 / 2.75f)){
			return end * (7.5625f * value * value) + start;
		}else if (value < (2 / 2.75f)){
			value -= (1.5f / 2.75f);
			return end * (7.5625f * (value) * value + .75f) + start;
		}else if (value < (2.5 / 2.75)){
			value -= (2.25f / 2.75f);
			return end * (7.5625f * (value) * value + .9375f) + start;
		}else{
			value -= (2.625f / 2.75f);
			return end * (7.5625f * (value) * value + .984375f) + start;
		}
	}
	
	public static float EaseInOutBounce(float start, float end, float value){
		end -= start;
		float d = 1f;
		if (value < d/2) return EaseInBounce(0, end, value*2) * 0.5f + start;
		else return EaseOutBounce(0, end, value*2-d) * 0.5f + end*0.5f + start;
	}

	public static float EaseInBack(float start, float end, float value){
		end -= start;
		value /= 1;
		float s = 1.70158f;
		return end * (value) * value * ((s + 1) * value - s) + start;
	}

	public static float EaseOutBack(float start, float end, float value){
		float s = 1.70158f;
		end -= start;
		value = (value / 1) - 1;
		return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
	}

	public static float EaseInOutBack(float start, float end, float value){
		float s = 1.70158f;
		end -= start;
		value /= .5f;
		if ((value) < 1){
			s *= (1.525f);
			return end / 2 * (value * value * (((s) + 1) * value - s)) + start;
		}
		value -= 2;
		s *= (1.525f);
		return end / 2 * ((value) * value * (((s) + 1) * value + s) + 2) + start;
	}

	public static float Punch(float amplitude, float value){
		float s = 9;
		if (value == 0){
			return 0;
		}
		if (value == 1){
			return 0;
		}
		float period = 1 * 0.3f;
		s = period / (2 * Mathf.PI) * Mathf.Asin(0);
		return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
    }
	
	public static float EaseInElastic(float start, float end, float value){
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d) == 1) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
			}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		return -(a * Mathf.Pow(2, 10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
	}
	
	public static float EaseOutElastic(float start, float end, float value)
	{
		//Thank you to rafael.marteleto for fixing this as a port over from Pedro's UnityTween
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d) == 1) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
			}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
	}
	
	public static float EaseInOutElastic(float start, float end, float value)
	{
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d/2) == 2) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
			}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
		return a * Mathf.Pow(2, -10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
	}
	#endregion
 
}