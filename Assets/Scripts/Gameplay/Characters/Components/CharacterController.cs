using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// kzlukos@gmail.com
// Handles UnitCommands
// (todo) holds an information about unit state
public class CharacterController : MonoBehaviour {

	private CharacterLocomotion _characterLocomotion;
	private IUnitActions _characterActions;

	//
	void Start()
	{
		_characterLocomotion = GetComponent<CharacterLocomotion> ();
		_characterActions = GetComponent<IUnitActions> ();
		PassUnitCommand (new RandomizePosititonCommand ());
	}

	//
	public void PassUnitCommand(RandomizePosititonCommand command)
	{
		Vector3 direction = ((RandomizePosititonCommand)command).direction;
		Vector3 newTargetPosition = MapManager.Instance.Map.GetRandomPoint (direction, transform.position);

		if(_characterLocomotion != null)
			_characterLocomotion.SetTargetPosition (newTargetPosition);
	}

	//
	public void PassUnitCommand(ActionCommand command)
	{
		switch (command.actionType) 
		{
		case ActionType.Greet:
			_characterActions.Greet();
			break;

		}
	}



}
