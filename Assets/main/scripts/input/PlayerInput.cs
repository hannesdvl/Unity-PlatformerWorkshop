using UnityEngine;
using System.Collections;

public class PlayerInput : AbstractInput
{
	public int playerNumber;

	public override bool GetButtonDown (InputButton button)
	{
		return Input.GetButtonDown("P"+playerNumber+"_"+button);
	}
	public override bool GetButtonUp (InputButton button)
	{
		return Input.GetButtonUp("P"+playerNumber+"_"+button);
	}
	public override bool GetButton (InputButton button)
	{
		return Input.GetButton("P"+playerNumber+"_"+button);
	}
}
