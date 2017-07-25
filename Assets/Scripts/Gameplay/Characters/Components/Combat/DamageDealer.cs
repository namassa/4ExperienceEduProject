using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Allows an object to deal damage and sets it's value
// kzlukos@gmail.com
// cooldown added
public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;
	[SerializeField]
	private float attackSpeed = 1f;

	private float _attackCooldown = 0f;

    //
	public void DealDamage (GameObject target)
    {

		if (_attackCooldown == 0f) {
			IDamageable targetHealth = target.GetComponent<IDamageable> ();
			if (targetHealth != null) {
				targetHealth.Damage (damage);
			}
			_attackCooldown = 1f / attackSpeed;
		}
	}

	//
	void Update()
	{
		_attackCooldown = Mathf.Max (_attackCooldown - Time.deltaTime, 0f);
	}

}
