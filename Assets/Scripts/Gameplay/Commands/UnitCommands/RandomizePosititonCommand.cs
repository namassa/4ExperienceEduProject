using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com 01.07.2017
// Now inherits from UnitCommand
// jarekdc@gmail.com
// Holds an object and information about a potential collission
public class RandomizePosititonCommand : UnitCommand
{
	public Vector3 direction;

	//
	public RandomizePosititonCommand (Vector3 v) : base(UnitCommandType.Repath)
	{
		direction = new Vector2 (v.x, v.y);
	}

	public RandomizePosititonCommand () : base(UnitCommandType.Repath)
	{
		direction = new Vector2 (0f, 0f);
	}

}
