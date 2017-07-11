using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UnitCommandType 
{
	Repath,
	PerformAction,
}
	
// kzlukos@gmail.com
// Base class for all unit commands
public class UnitCommand : CommandBase {

	public UnitCommandType Type { get; private set; }

	//
	public UnitCommand(UnitCommandType type)
	{
		Type = type;
	}
		
}
