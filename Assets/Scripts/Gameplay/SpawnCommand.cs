using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Spawn command containing prefab name
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