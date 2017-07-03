using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public struct Monster
    {
        public MonsterType monsterType;
        public int count;
    }

    [SerializeField] protected GameObject orc;
    [SerializeField] protected GameObject ogre;
    [SerializeField] protected GameObject goblin;

    public void RespawnMonsterByType(MonsterType monsterType, int count)
    {
        var respawnMonsterCommand = GetComponent<RespawnMonsterCommand>();

        Monster monster;
        monster.monsterType = monsterType;
        monster.count = count;

        switch (monster.monsterType)
        {
            case MonsterType.Orc:
                respawnMonsterCommand.MonsterPrefab = orc;
                respawnMonsterCommand.Position = new Vector3(0, 0, 0);
                break;
            case MonsterType.Ogre:
                respawnMonsterCommand.MonsterPrefab = ogre;
                respawnMonsterCommand.Position = new Vector3(1, 1, 1);
                break;
            case MonsterType.Goblin:
                respawnMonsterCommand.MonsterPrefab = goblin;
                respawnMonsterCommand.Position = new Vector3(2, 2, 2);
                break;
        }

        for (int i = 0; i < monster.count; i++)
        {
            respawnMonsterCommand.ExecuteCommand();
        }
    }
}