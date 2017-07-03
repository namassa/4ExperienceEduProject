using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FEEDBACK
// karol.ryt@gmail.com
// 1. LINQ jest fajny ale niewydajny
// 2. tu uzyj Dictonary<string,GameObject> i masz hashtablice co po stringu daje prefaba:)

// jarekdc@gmail.com
// Holds enemy prefabs and instantiates them
public class EnemyFactory : MonoBehaviour
{
    // could use a dictonary if we have more enemies
    // we used string to avoid adding new enum types everytime we add a new enemy
    // we don't have to specify one big enum for all enemy types or define multiple enums if we want customize available enemy types
    [SerializeField]
    private GameObject[] enemyPrefabs;

    //
    public void SpawnEnemy(string enemyPrefabName)
    {

        GameObject requestedPrefab = System.Array.Find(enemyPrefabs, (prefab => prefab.name == enemyPrefabName));

        if (requestedPrefab != null)
        {
            Instantiate(requestedPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("requested prefab not found, name: " + enemyPrefabName);
        }
    }
}
