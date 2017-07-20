using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Scriptable object to hold AI parameters

[CreateAssetMenu(fileName = "NPCBehaviour", menuName = "NPCBehaviour", order = 1)]
public class NPCBehaviour : ScriptableObject
{
    public int characterCourage;
}
