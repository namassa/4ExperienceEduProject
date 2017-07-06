using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Executes movment towards target position
[RequireComponent(typeof(CharacterController))]
public class UnitLocomotion : MonoBehaviour 
{
	public System.Action onDestinationReached;

	[Header("Speed parameters")]
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private float rotationSpeed;

	[SerializeField]
	private float destinationReachedTolerance = 0.1f;

	//
	private Vector3? _targetPosition;
	private CharacterController _characterController;

	//
	void Start()
	{
		_characterController = GetComponent<CharacterController> ();
	}

	//
	public void SetTargetPosition(Vector3? position)
	{
		_targetPosition = position;
	}

	//
	void Update () 
	{
		if (_targetPosition != null) 
		{
			Vector3 targetDirection = (transform.position - (Vector3)_targetPosition);

			//Destination reached
			if (targetDirection.magnitude < destinationReachedTolerance) 
			{
				_targetPosition = null;
				onDestinationReached ();
				return;
			}
				
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.smoothDeltaTime);

			if(Vector3.Angle(transform.forward, targetDirection) < 30)
				_characterController.SimpleMove (targetDirection.normalized * movementSpeed);

		}
	}


}
