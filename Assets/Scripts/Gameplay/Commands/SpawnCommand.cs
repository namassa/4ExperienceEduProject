using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Spawn command class accepting prefab and factory parameters
[System.Serializable]
public class SpawnCommand : CommandBase 
{
	public string enemyPrefabName;

	//
	public SpawnCommand(string requestedPrefabName) 
	{
		enemyPrefabName = requestedPrefabName;
	}
}