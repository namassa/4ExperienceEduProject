using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// class add and remove monsters by type

public class UIController : InputController
{
    public static List<GameObject> monsters;

    private void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster").ToList();
    }

    public void RespawnOrc()
    {
        _factoryController.RespawnMonsterByType(MonsterType.Orc, numberOfMonstersToRespawn);
    }

    public void RespawnOgre()
    {
        _factoryController.RespawnMonsterByType(MonsterType.Ogre, numberOfMonstersToRespawn);
    }

    public void RespawnGoblin()
    {
        _factoryController.RespawnMonsterByType(MonsterType.Goblin, numberOfMonstersToRespawn);
    }

    public void RespawnVillager()
    {
        _factoryController.RespawnCharacterByType(CharacterTypes.Villager, numberOfMonstersToRespawn);
    }

    public void RespawnHero()
    {
        _factoryController.RespawnCharacterByType(CharacterTypes.Hero, numberOfMonstersToRespawn);
    }

    public void DeleteOrc()
    {
        GameObject monster = monsters.FirstOrDefault(x => x.GetComponent<Monster>().monsterType == MonsterType.Orc);
        Destroy(monster);
    }

    public void DeleteOgre()
    {
        GameObject monster = monsters.FirstOrDefault(x => x.GetComponent<Monster>().monsterType == MonsterType.Ogre);
        Destroy(monster);
    }

    public void DeleteGoblin()
    {
        GameObject monster = monsters.FirstOrDefault(x => x.GetComponent<Monster>().monsterType == MonsterType.Goblin);
        Destroy(monster);
    }
}