using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Detects collisions with other objects
// Holds a list of other characters in field of view
public class CharacterPerception : MonoBehaviour 
{

	private CharacterController _characterController;
	private int _charactersLayer;

	//
	void Start()
	{
		_characterController = GetComponent<CharacterController> ();
		_charactersLayer = LayerMask.NameToLayer ("Units");
	}

	//
	void Update()
	{

	}

	//
	void OnCollisionEnter(Collision collision) 
	{
		// With other characters
		if (collision.gameObject.layer == _charactersLayer) 
		{
			var greetCmd = new ActionCommand (ActionType.Greet);
			var repathCmd = new RandomizePosititonCommand (transform.position - collision.transform.position);

			_characterController.PassUnitCommand (greetCmd);
			_characterController.PassUnitCommand (repathCmd);
		}
	}

}
