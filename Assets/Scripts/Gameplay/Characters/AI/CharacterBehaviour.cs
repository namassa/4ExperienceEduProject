using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarekdc@gmail.com
// Scriptable object to hold AI parameters

[CreateAssetMenu(fileName = "CharacterBehaviour", menuName = "CharacterBehaviour", order = 1)]
public class CharacterBehaviour : ScriptableObject
{
    public int characterCourage;
}
