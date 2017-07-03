using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Recieves spawn commands and passes them to the factory
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

	//
	private void Awake() 
	{
		_instance = this;
	}

	//
	public void PassSpawnCommand(SpawnCommand command) 
	{
		factory.SpawnEnemy (command);
	}

}
