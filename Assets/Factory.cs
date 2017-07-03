using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// FEEDBACK:
// karol.ryt@gmail.com
// 1. Gdzie sa maile i daty jako podpisy
// 2. Gdzie opisy co realizuja klasy
// 3. Nie potrzeba nam tu interfejsu;) Wazne ze klasa ma funkcja publiczna
// 4. Uporządkowac pliki bo sa w root
// 5. MonsterType bym zmienil w struct ktory zawiera a funkcja fajnie by zwala sie ExecuteCOmmand
/*
struct MonsterFactoryCommand {
	public enum MonsterType;
	public int count; // itd
}
*/

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
