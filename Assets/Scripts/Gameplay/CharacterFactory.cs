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
    private string[] _prefabNames;
    private Dictionary <string, GameObject> _characterPrefabs;
    
    [SerializeField]
    private Transform characterSpawnPosition;
    private FactoriesController factoriesCtrl;

    //
    void Awake()
	{
        factoriesCtrl = FindObjectOfType<FactoriesController>();

		_characterPrefabs = new Dictionary<string, GameObject>();
        foreach (GameObject prefab in prefabList)
        {
            _characterPrefabs.Add(prefab.name, prefab);
        }

        _prefabNames = new string[prefabList.Length];
        _characterPrefabs.Keys.CopyTo(_prefabNames, 0);

        factoriesCtrl.AddFactory(this, _prefabNames);
    }

    //
    void OnDisable()
    {
        factoriesCtrl.RemoveFactory(this, _prefabNames);
    }

    //
    public GameObject SpawnCharacter(SpawnCommand spawnCommand)
    {
		GameObject requestedPrefab = _characterPrefabs [spawnCommand.characterPrefabName];

        Vector3 correctHeightSpawnPos = new Vector3(characterSpawnPosition.position.x, 
            requestedPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.extents.y * requestedPrefab.transform.localScale.y, 
            characterSpawnPosition.position.z);

        GameObject insantiatedCharacter = Instantiate(requestedPrefab, correctHeightSpawnPos, characterSpawnPosition.rotation);
        return insantiatedCharacter;
    }
}
