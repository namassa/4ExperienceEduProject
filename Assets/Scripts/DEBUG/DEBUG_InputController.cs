using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jarek@gmail.com
// Creates spawn commands and passes them to the FactoryController
// Command patterns are exposed to the inspector
public class DEBUG_InputController : MonoBehaviour 
{
	// To allow modification from the editor level
	[System.Serializable]
	private class ButtonSpawnCmdBind
	{
		public KeyCode keyCode;
		public Button button;
		public SpawnCommand cmd;
	}

	[Header("Key Press Commands")]
	[SerializeField]
	private ButtonSpawnCmdBind[] spawnCmd;

	//
	void Awake ()
	{
		foreach (ButtonSpawnCmdBind cmdBind in spawnCmd) 
		{
			cmdBind.button.onClick.AddListener (() => FactoriesController.Instance.PassSpawnCommand (new SpawnCommand (cmdBind.cmd.characterPrefabName)));
			cmdBind.button.GetComponentInChildren<Text> ().text = "Spawn " + cmdBind.cmd.characterPrefabName;
		}
	}

	//
	void Update () 
	{
		foreach (ButtonSpawnCmdBind cmdBind in spawnCmd)
			if (Input.GetKeyDown (cmdBind.keyCode))
				FactoriesController.Instance.PassSpawnCommand (new SpawnCommand (cmdBind.cmd.characterPrefabName)); // Clone() should be used instead new()
	}
}

