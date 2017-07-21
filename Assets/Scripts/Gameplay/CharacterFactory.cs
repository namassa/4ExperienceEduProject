using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// jarekdc@gmail.com
// Holds enemy prefabs and instantiates them
public class CharacterFactory : MonoBehaviour
{
    // could use a dictonary if we have more enemies
    // we used string to avoid adding new enum types everytime we add a new enemy
    // we don't have to specify one big enum for all enemy types or define multiple enums if we want customize available enemy types
    [SerializeField]
    private GameObject[] prefabList;
	private Dictionary <string, GameObject> _characterPrefabs;

    [SerializeField]
    private Transform characterSpawnPosition;
    private FactoriesController factoriesCtrl;

    //
    void Awake()
	{
        factoriesCtrl = FindObjectOfType<FactoriesController>();
        factoriesCtrl.AddFactory(this);

		_characterPrefabs = new Dictionary<string, GameObject>();
		foreach (GameObject prefab in prefabList)
			_characterPrefabs.Add (prefab.name, prefab);
	}

    //
    void OnDisable()
    {
        factoriesCtrl.RemoveFactory(this);
    }

    //
    public GameObject SpawnCharacter(SpawnCommand spawnCommand)
    {
		GameObject requestedPrefab = _characterPrefabs [spawnCommand.characterPrefabName];
        if (requestedPrefab != null)
        {
            GameObject insantiatedCharacter = Instantiate(requestedPrefab, characterSpawnPosition.position, Quaternion.identity);
            return insantiatedCharacter;
        }
        else
        {
			Debug.LogWarning("requested prefab not found, name: " + spawnCommand.characterPrefabName);
            return null;
        }
    }
}
