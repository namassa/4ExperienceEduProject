using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Detects collisions with other objects
public class CharacterCollisions : MonoBehaviour 
{
	private CharacterController _characterController;
	private int _layer;

	//
	void Start()
	{
		_characterController = GetComponent<CharacterController> ();
		_layer = LayerMask.NameToLayer ("Units");
	}
		
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.layer == _layer) 
		{
			var greetCmd = new ActionCommand (ActionType.Greet);
			var repathCmd = new RandomizePosititonCommand (transform.position - collision.transform.position);

			_characterController.PassUnitCommand (greetCmd);
			_characterController.PassUnitCommand (repathCmd);
		}
	}

}
