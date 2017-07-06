using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Holds an object and information about a potential collission
public class RandomizePosititonCommand
{
	public GameObject sender;
	public Vector3 collisionDirection;

	//
	public RandomizePosititonCommand (GameObject senderObject, Vector3 direction)
	{
		sender = senderObject;
		collisionDirection = direction;
	}

}
