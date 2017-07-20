using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// jarekdc@gmail.com
// Scriptable object editor
[CustomEditor(typeof(CharacterBehaviour))]
public class CharacterBehaviourEditor : Editor
{
    //
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
