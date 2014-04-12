using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class Player : MonoBehaviour
{
	private SKStateMachine<PlayerModel> _machine;
	
	void Awake()
	{
		_machine = new SKStateMachine<PlayerModel>(GetComponent<PlayerModel>(), new PlayerAirState());
		_machine.addState(new PlayerGroundedState());
		_machine.addState(new PlayerGroundedJumpTransition());
	}
	
	void Update()
	{
		_machine.update( Time.deltaTime );
		gameObject.name = "Player ("+_machine.currentState.GetType().ToString() +")";
	}
}