using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// jarekdc@gmail.com
// Holds enemy prefabs and instantiates them
public class EnemyFactory : MonoBehaviour
{
    // could use a dictonary if we have more enemies
    // we used string to avoid adding new enum types everytime we add a new enemy
    // we don't have to specify one big enum for all enemy types or define multiple enums if we want customize available enemy types
    [SerializeField]
    private GameObject[] prefabList;
	private Dictionary <string, GameObject> _enemyPrefabs;

	//
	void Awake()
	{
		_enemyPrefabs = new Dictionary<string, GameObject>();
		foreach (GameObject prefab in prefabList)
			_enemyPrefabs.Add (prefab.name, prefab);
	}

    //
	public void SpawnEnemy(SpawnCommand spawnCommand)
    {
		
		GameObject requestedPrefab = _enemyPrefabs [spawnCommand.enemyPrefabName];
        if (requestedPrefab != null)
        {
            Instantiate(requestedPrefab, transform.position, Quaternion.identity);
        }
        else
        {
			Debug.LogWarning("requested prefab not found, name: " + spawnCommand.enemyPrefabName);
        }
    }
}
