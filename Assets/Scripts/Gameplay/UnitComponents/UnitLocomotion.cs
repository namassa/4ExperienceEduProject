using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Executes movment towards target position
[RequireComponent(typeof(UnitController))]
public class UnitLocomotion : MonoBehaviour 
{
	[Header("Speed parameters")]
	[SerializeField]
	private float movementSpeed = 1;
	[SerializeField]
	private float rotationSpeed = 1;

	[Header("Movement parameters")]
	[SerializeField]
	private float destinationReachedTolerance = 0.1f;
	[SerializeField]
	private float startMovingAngle = 30f;

	//
	private UnitController _unitController;
	private Rigidbody _rigidbody;
	private Vector3? _targetPosition;

	//
	void Start()
	{
		_unitController = GetComponent<UnitController> ();
		_rigidbody = GetComponent<Rigidbody> ();
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
			Vector3 targetDirection = ((Vector3)_targetPosition - transform.position);
			targetDirection.y = 0f;

			Quaternion targetRotation = Quaternion.LookRotation (targetDirection.normalized);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.smoothDeltaTime);

			if(Vector3.Angle(transform.forward, targetDirection) < startMovingAngle)
				transform.position += (transform.forward * movementSpeed * Time.smoothDeltaTime);

			//Destination reached
			if (targetDirection.magnitude < destinationReachedTolerance) 
			{
				_targetPosition = null;
				_unitController.PassUnitCommand (new RandomizePosititonCommand ());
				return;
			}

		}
	}
		
	#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * 3f);
		if (_targetPosition != null)
			Gizmos.DrawWireSphere ((Vector3)_targetPosition, 0.5f);
	}
	#endif

}
