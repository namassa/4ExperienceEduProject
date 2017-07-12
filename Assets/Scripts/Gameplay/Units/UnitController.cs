using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// kzlukos@gmail.com
// Handles UnitCommands and holds an information about unit's state
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
	public void PassUnitCommand(UnitCommand command)
	{
		switch (command.Type) 
		{
		case UnitCommandType.Repath:
			Vector3 direction = ((RandomizePosititonCommand)command).direction;
			Vector3 newTargetPosition = MapManager.Instance.Map.GetRandomPoint (direction, transform.position);

			if(_unitLocomotion != null)
				_unitLocomotion.SetTargetPosition (newTargetPosition);
			break;


		case UnitCommandType.PerformAction:
			//string actionType = ((command)command).direction;
			break;
		}

	}

}
