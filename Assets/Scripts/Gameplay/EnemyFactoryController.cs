using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//kzlukos@gmail.com
//
public class EnemyFactoryController : MonoBehaviour {

	[SerializeField] EnemyFactory factory;
	private List<Command> _commandList = new List<Command>();

	public void PassSpawnCommand(Command command) {
		
		SpawnCommand spawnCommand = command as SpawnCommand;

		spawnCommand.factory = factory;
		spawnCommand.Execute ();
		_commandList.Add (spawnCommand);

	}

}


/*
SpawnCommand cmd = new SpawnCommand("orc");
EnemyFactoryController.Indtance.PassSpawnCommand(cmd);
*/



//
//
public interface Command {
	void Execute ();
}

//
//
public class SpawnCommand : Command {

	public EnemyFactory factory;
	public string EnemyPrefabName { get; private set; }

	public SpawnCommand(string enemyPrefabName) 
	{
		EnemyPrefabName = enemyPrefabName;
	}

	public void Execute() {
		factory.SpawnEnemy (EnemyPrefabName);
	}
		
}