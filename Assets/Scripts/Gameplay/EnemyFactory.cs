using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// jarekdc@gmail.com
// Holds enemy prefabs and instantiates them at a random position on the map
public class EnemyFactory : MonoBehaviour
{
    // could use a dictonary if we have more enemies
    // we used string to avoid adding new enum types everytime we add a new enemy
    // we don't have to specify one big enum for all enemy types or define multiple enums if we want customize available enemy types
    [SerializeField]
    private GameObject[] prefabList;
	private Dictionary <string, GameObject> _enemyPrefabs;

    [SerializeField]
    private Map map;

	//
	void Awake()
	{
		_enemyPrefabs = new Dictionary<string, GameObject>();
		foreach (GameObject prefab in prefabList)
			_enemyPrefabs.Add (prefab.name, prefab);
	}

    //
	public GameObject SpawnEnemy(SpawnCommand spawnCommand)
    {
		GameObject requestedPrefab = _enemyPrefabs [spawnCommand.enemyPrefabName];
        if (requestedPrefab != null)
        {
            GameObject insantiatedEnemy = Instantiate(requestedPrefab, GetRandomSpawnPosition(requestedPrefab), Quaternion.identity);
            return insantiatedEnemy;
        }
        else
        {
			Debug.LogWarning("requested prefab not found, name: " + spawnCommand.enemyPrefabName);
            return null;
        }
    }

    //
    Vector3 GetRandomSpawnPosition(GameObject requestedPrefab)
    {
        Vector3 spawnPosition;
        Vector3 mapRandomPoint = map.GetRandomFreePoint();
        spawnPosition.x = mapRandomPoint.x;
        spawnPosition.y = requestedPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.extents.y * requestedPrefab.transform.localScale.y;
        spawnPosition.z = mapRandomPoint.z;

        return spawnPosition;
    }
}
