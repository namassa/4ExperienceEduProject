using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState 
{
	Idle,
	Moving,
	PerformingAction
}

// kzlukos@gmail.com
// Holds an information about unit's state
public class UnitController : MonoBehaviour {

	public UnitState State { get; private set; }

	//
	void Start()
	{
		State = UnitState.Idle;
	}

	//
	private void OnDestinationReachedHandler()
	{
		var cmd = new RandomizePosititonCommand (gameObject, Vector3.zero);
		EnemyBehaviourController.Instance.PassRandomizePositionCommand (cmd);
	}
}
