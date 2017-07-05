using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Sets up object's health and exposes a method to decrease it
public class Health : MonoBehaviour, IDamageable
{
    public float HealthValue { get; set; }
    private float healthValue;

    [SerializeField]
    private float startingHealth;

    //
    private void Awake()
    {
        HealthValue = startingHealth;
    }

    //
    public void Damage (float damageTaken)
    {
        HealthValue -= damageTaken;
	}
}
