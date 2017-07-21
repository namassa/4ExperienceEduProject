using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// kzlukos@gmail.com
// Recieves spawn commands and passes them to the factory
public class FactoriesController : MonoBehaviour 
{
	//
	private static FactoriesController _instance;
	public static FactoriesController Instance 
	{
		get { return _instance; }
	}

	//
	List<CharacterFactory> charFactories = new List<CharacterFactory>();
    List<GameObject> spawnedCharacters = new List<GameObject>();

	//
	private void Awake() 
	{
		_instance = this;
	}

    //
    public void AddFactory(CharacterFactory factory)
    {
        charFactories.Add(factory);
    }

    //
    public void RemoveFactory(CharacterFactory factory)
    {
        charFactories.Remove(factory);
    }

    //
    public void PassSpawnCommand(SpawnCommand command) 
	{
        // TODO get a random factory from a list with that given prefab // register with prefabs
		//GameObject newCharacter = factory.SpawnCharacter (command);
  //      if (newCharacter != null)
  //      {
  //          spawnedCharacters.Add(newCharacter);
  //      }
	}

    //
    private void RemoveCharacterFromList(GameObject character)
    {
        // should also destroy the enemy gameObject?
        spawnedCharacters.Remove(character);
    }
}
