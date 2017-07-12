using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// kzlukos@gmail.com
// Handles UnitCommands
// (todo) holds an information about unit state
public class UnitController : MonoBehaviour {

	private UnitLocomotion _unitLocomotion;
	private IUnitActions _unitActions;

	//
	void Start()
	{
		_unitLocomotion = GetComponent<UnitLocomotion> ();
		_unitActions = GetComponent<IUnitActions> ();
		PassUnitCommand (new RandomizePosititonCommand ());
	}


	//
	public void PassUnitCommand(RandomizePosititonCommand command)
	{
		Vector3 direction = ((RandomizePosititonCommand)command).direction;
		Vector3 newTargetPosition = MapManager.Instance.Map.GetRandomPoint (direction, transform.position);

		if(_unitLocomotion != null)
			_unitLocomotion.SetTargetPosition (newTargetPosition);

	}

	//
	public void PassUnitCommand(ActionCommand command)
	{
		switch (command.actionType) 
		{
		case ActionType.Greet:
			_unitActions.Greet();
			break;

		}
	}



}
