using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ButtonState { Pressed, Down, Released, Up }

public class SimulateInput : AbstractInput
{

	public Dictionary<InputButton, ButtonState> buttonStates;

	void Awake()
	{
		buttonStates = new Dictionary<InputButton, ButtonState> ();
		buttonStates.Add (InputButton.Action, ButtonState.Up);
		buttonStates.Add (InputButton.Jump, ButtonState.Up);
		buttonStates.Add (InputButton.Left, ButtonState.Up);
		buttonStates.Add (InputButton.Right, ButtonState.Up);
	}

	public override bool GetButtonDown (InputButton button)
	{
		return buttonStates [button] == ButtonState.Pressed;
	}

	public override bool GetButtonUp (InputButton button)
	{
		return buttonStates [button] == ButtonState.Released;
	}

	public override bool GetButton (InputButton button)
	{
		return buttonStates [button] == ButtonState.Down || buttonStates [button] == ButtonState.Pressed;
	}

	public void PressButton (InputButton button)
	{
		buttonStates[button] = ButtonState.Pressed;
	}

	public void ReleaseButton (InputButton button)
	{
		buttonStates[button] = ButtonState.Released;
	}

	void LateUpdate()
	{
		/*
		foreach (InputButton key in buttonStates.Keys)
		{
			if(buttonStates[key] == ButtonState.Pressed) buttonStates[key] = ButtonState.Down;
			if(buttonStates[key] == ButtonState.Released) buttonStates[key] = ButtonState.Up;
		}
		*/
	}
}
