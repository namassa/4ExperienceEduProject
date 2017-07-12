using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
	Greet
}
	
// kzlukos@gmail.com
// Triggers action specified by actionType
public class ActionCommand : UnitCommand {

	public ActionType actionType;

	//
	public ActionCommand (ActionType type)
	{
		actionType = type;
	}
		
}
