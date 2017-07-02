using UnityEngine;

public class RespawnMonsterCommand : MonsterFactory, ICommand
{
    public MonsterType monsterType;

    public void Execute()
    {
        switch (monsterType)
        {
            case MonsterType.Orc:
                Instantiate(orc, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case MonsterType.Ogre:
                Instantiate(ogre, new Vector3(1, 1, 1), Quaternion.identity);
                break;
            case MonsterType.Goblin:
                Instantiate(goblin, new Vector3(2, 2, 2), Quaternion.identity);
                break;
        }
    }
}