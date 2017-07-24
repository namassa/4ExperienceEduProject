using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmial.com
// Base class for all characters
public abstract class Character : MonoBehaviour, IUnitActions
{

	[SerializeField] int _level = 1;
	public int Level 
	{ 
		get { return _level; } 
	}

	public abstract void Greet();

}
