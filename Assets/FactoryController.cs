using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FEEDBACK
// karol.ryt@gmail.com
// 1. NIE UZYWAMY FindObjectOfType:) jak tylko mozna, mozna lepiej to zrobic np dac go jako child w hierarchi.

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
