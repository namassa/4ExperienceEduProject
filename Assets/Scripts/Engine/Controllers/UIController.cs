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
    public static List<GameObject> characters;

    private void Update()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster").ToList();
        characters = GameObject.FindGameObjectsWithTag("Character").ToList();
    }

    public void RespawnOrc()
    {
        _factoryController.RespawnMonstersByType(MonsterType.Orc, numberOfObjectsToRespawn);
    }

    public void RespawnOgre()
    {
        _factoryController.RespawnMonstersByType(MonsterType.Ogre, numberOfObjectsToRespawn);
    }

    public void RespawnGoblin()
    {
        _factoryController.RespawnMonstersByType(MonsterType.Goblin, numberOfObjectsToRespawn);
    }

    public void RespawnVillager()
    {
        _factoryController.RespawnCharactersByType(CharacterType.Villager, numberOfObjectsToRespawn);
    }

    public void RespawnHero()
    {
        _factoryController.RespawnCharactersByType(CharacterType.Hero, numberOfObjectsToRespawn);
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

    public void DeleteVillager()
    {
        GameObject character = characters.FirstOrDefault(x => x.GetComponent<Villager>().characterType == CharacterType.Villager);
        Destroy(character);
    }

    public void DeleteHero()
    {
        GameObject character = characters.FirstOrDefault(x => x.GetComponent<Hero>().characterType == CharacterType.Hero);
        Destroy(character);
    }
}