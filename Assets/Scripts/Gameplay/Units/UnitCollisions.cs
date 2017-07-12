using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Detects collisions with other objects
public class UnitCollisions : MonoBehaviour 
{

	private UnitController _unitController;
	private int _layer;

	//
	void Start()
	{
		_unitController = GetComponent<UnitController> ();
		_layer = LayerMask.NameToLayer ("Units");
	}

	//
	void OnCollisionEnter(Collision collision) 
	{

		if (collision.gameObject.layer == _layer) 
		{
			var cmd = new RandomizePosititonCommand (transform.position - collision.transform.position);
			_unitController.PassUnitCommand (cmd);
		}
	}

}
