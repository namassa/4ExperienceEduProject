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
	Dictionary<string, List<CharacterFactory>> _charFactories = new Dictionary<string, List<CharacterFactory>>();
    List<GameObject> _spawnedCharacters = new List<GameObject>();

	//
	private void Awake() 
	{
		_instance = this;
	}

    //
    public void AddFactory(CharacterFactory factory, string[] characterPrefabNames)
    {
        for (int i = 0; i < characterPrefabNames.Length; i++)
        {
            if (_charFactories.ContainsKey(characterPrefabNames[i]))
            {
                _charFactories[characterPrefabNames[i]].Add(factory);
            }
            else
            {
                _charFactories.Add(characterPrefabNames[i], new List<CharacterFactory> { factory });
            }
        }
    }

    //
    public void RemoveFactory(CharacterFactory factory, string[] characterPrefabNames)
    {
        for (int i = 0; i < characterPrefabNames.Length; i++)
        {
            if (_charFactories.ContainsKey(characterPrefabNames[i]))
            {
                if (_charFactories[characterPrefabNames[i]].Contains(factory))
                {
                    _charFactories[characterPrefabNames[i]].Remove(factory);
                }
            }
        }
    }

    //
    public void PassSpawnCommand(SpawnCommand command) 
	{
        if (_charFactories.ContainsKey(command.characterPrefabName))
        {
            CharacterFactory[] availableFactories = _charFactories[command.characterPrefabName].ToArray();

            if (availableFactories.Length > 0)
                availableFactories[Random.Range(0, availableFactories.Length)].SpawnCharacter(command);
            else
                Debug.LogWarning("Didn't find any factory spawning requested prefab! Prefab name: " + command.characterPrefabName);
        }
        else
            Debug.LogWarning("Didn't find any factory spawning requested prefab! Prefab name: " + command.characterPrefabName);
    }

    //
    private void RemoveCharacterFromList(GameObject character)
    {
        // should also destroy the enemy gameObject?
		_spawnedCharacters.Remove(character);
    }
}
