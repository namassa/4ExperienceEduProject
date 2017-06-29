using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{

    private Factory monsterFactory;

    private void Awake()
    {
        monsterFactory = FindObjectOfType<Factory>();
    }

    public void SpawnMonsters(Factory.MonsterType monsterType)
    {
        monsterFactory.Execute(monsterType);
    }
}
