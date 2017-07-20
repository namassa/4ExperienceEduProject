using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// jarekdc@gmail.com
// Scriptable object editor
[CustomEditor(typeof(NPCBehaviour))]
public class NPCBehaviourEditor : Editor
{
    //
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
