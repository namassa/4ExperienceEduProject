using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Actions implementation for enemy units
public class EnemyUnitActions : MonoBehaviour, IUnitActions {

	public void Greet() {
		GetComponent<Rigidbody> ().AddForce (Vector3.up * 5f, ForceMode.Impulse);
	}

}
