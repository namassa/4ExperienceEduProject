using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory :  MonoBehaviour, ICommand
{

    public enum MonsterType
    {
        Orc,
        Ogre,
        Goblin
    }

    GameObject newMonster;
    [SerializeField]
    GameObject orc;
    [SerializeField]
    GameObject ogre;
    [SerializeField]
    GameObject goblin;

    public void Execute(MonsterType monsterType)
    {
        switch (monsterType)
        {
            case MonsterType.Orc:
                 newMonster = Instantiate(orc, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case MonsterType.Ogre:
                 newMonster = Instantiate(ogre, new Vector3(1, 1, 1), Quaternion.identity);

                break;
            case MonsterType.Goblin:
                 newMonster = Instantiate(goblin, new Vector3(2, 2, 2), Quaternion.identity);

                break;
            default:
                break;
        }
    }
}
