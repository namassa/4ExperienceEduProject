using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Recieves & executes spawn commands
public class EnemyFactoryController : MonoBehaviour 
{
	//
	private static EnemyFactoryController _instance;
	public static EnemyFactoryController Instance 
	{
		get { return _instance; }
	}

	//
	[SerializeField] EnemyFactory factory;
	private List<CommandBase> _commandList = new List<CommandBase>();


	//
	private void Awake() 
	{
		_instance = this;
	}

	//
	public void PassSpawnCommand(CommandBase command) 
	{

		SpawnCommand spawnCommand = command as SpawnCommand;
		spawnCommand.factory = factory;
		spawnCommand.Execute ();
		_commandList.Add (spawnCommand);
	}
}
