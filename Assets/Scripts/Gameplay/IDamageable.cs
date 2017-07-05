using System.Collections;
using UnityEngine;

// jarekdc@gmail.com
// Defines an interface for objects that have health and can be damaged
public interface IDamageable
{
    //
    float HealthValue { get; set; }

    //
    void Damage(float damageTaken);
}
