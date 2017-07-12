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

	//Different implementation for different units?
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.layer == _layer) 
		{
			var greetCmd = new ActionCommand (ActionType.Greet);
			var repathCmd = new RandomizePosititonCommand (transform.position - collision.transform.position);

			_unitController.PassUnitCommand (greetCmd);
			_unitController.PassUnitCommand (repathCmd);
		}
	}

}
