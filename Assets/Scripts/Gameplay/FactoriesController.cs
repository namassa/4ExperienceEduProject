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
	List<CharacterFactory> _charFactories = new List<CharacterFactory>();
    List<GameObject> _spawnedCharacters = new List<GameObject>();

	//
	private void Awake() 
	{
		_instance = this;
	}

    //
    public void AddFactory(CharacterFactory factory)
    {
		_charFactories.Add(factory);
    }

    //
    public void RemoveFactory(CharacterFactory factory)
    {
		_charFactories.Remove(factory);
    }

    //
    public void PassSpawnCommand(SpawnCommand command) 
	{
		// Optimization (dictionary) needed
		foreach(CharacterFactory factory in _charFactories)
		{
			GameObject newCharacter = factory.SpawnCharacter (command);
			if (newCharacter != null)
			{
				_spawnedCharacters.Add(newCharacter);
				break;
			}
		}

	}

    //
    private void RemoveCharacterFromList(GameObject character)
    {
        // should also destroy the enemy gameObject?
		_spawnedCharacters.Remove(character);
    }
}
