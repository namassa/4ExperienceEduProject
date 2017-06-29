using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    FactoryController monsterFactoryController;

    private void Awake()
    {
        monsterFactoryController = gameObject.AddComponent<FactoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            monsterFactoryController.SpawnMonsters(Factory.MonsterType.Orc);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            monsterFactoryController.SpawnMonsters(Factory.MonsterType.Ogre);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            monsterFactoryController.SpawnMonsters(Factory.MonsterType.Goblin);
        }
    }
}
