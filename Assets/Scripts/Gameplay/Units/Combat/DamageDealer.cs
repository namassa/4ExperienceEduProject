using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Allows an object to deal damage and sets it's value
public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;
	
    //
	public void DealDamage (GameObject target)
    {
        IDamageable targetHealth = target.GetComponent<IDamageable>();
        if (targetHealth != null)
        {
            targetHealth.Damage(damage);
        }
	}
}
