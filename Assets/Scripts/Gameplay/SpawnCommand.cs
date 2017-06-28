using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Spawn command class accepting prefab and factory parameters
[System.Serializable]
public class SpawnCommand : CommandBase 
{
	[HideInInspector]
	public EnemyFactory factory;
	public string enemyPrefabName;

	//
	public SpawnCommand(string requestedPrefabName) 
	{
		enemyPrefabName = requestedPrefabName;
	}

	//
	override public void Execute() 
	{
		factory.SpawnEnemy (enemyPrefabName);
	}
}