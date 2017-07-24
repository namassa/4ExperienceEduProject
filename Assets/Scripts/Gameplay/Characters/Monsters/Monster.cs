using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Base class for all monsters
public class Monster : Character
{
	//
	override public void Greet() {
		GetComponent<Rigidbody> ().AddForce (Vector3.up * 5f, ForceMode.Impulse);
	}

}
