using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Base class for command object
[System.Serializable]
public abstract class CommandBase 
{
	public abstract void Execute ();
}