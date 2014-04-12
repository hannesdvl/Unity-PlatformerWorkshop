using UnityEngine;
using System.Collections;

public abstract class AbstractInput : MonoBehaviour
{
	public abstract bool GetButtonDown (InputButton button);
	public abstract bool GetButtonUp (InputButton button);
	public abstract bool GetButton (InputButton button);
}
