using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FEEDBACK
// karol.ryt@gmail.com
// 1. Komendy powinny docierac do obiektu i on je wykonuje czyli przechowywanie odbiornika w komendzie jest zbedne
// Czyli tworzysz komende, ustawiasz jej parametry czyli np typ monstera i np liczba i wysylasz to do fabryki do funkcji co przyjmuje komende
// 2. Defacto masz teraz cos ala obiekt kontrolny ktory deleguje komendy dalej
// 3. Lista tu zbedna bo one powinny leciec i co dopiero zbierac sie w fabryce ze ona sciaga z stosu. Kontroller tylko mowi co ma robic. 
// 4. Idealnym przykladem kontrollera jest jakby MVC takie kontroler UI steruje wlasnie tak ze wysyla komendy do fabryki.

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
