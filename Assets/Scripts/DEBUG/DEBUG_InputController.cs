using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jarek@gmail.com
// Create spawn commands and passes them to the FactoryController
// Command patterns are exposed to the inspector
public class DEBUG_InputController : MonoBehaviour 
{
	// To allow modification from the editor level
	[System.Serializable]
	private class ButtonSpawnCmdBind
	{
		public KeyCode keyCode;
		public SpawnCommand cmd;
	}

	[SerializeField]
	private ButtonSpawnCmdBind[] spawnCmd;

	//
	void Update () 
	{
		foreach (ButtonSpawnCmdBind cmdBind in spawnCmd)
			if (Input.GetKeyDown (cmdBind.keyCode))
				EnemyFactoryController.Instance.PassSpawnCommand (new SpawnCommand (cmdBind.cmd.enemyPrefabName)); // Clone() should be used instead new()
	}
}

