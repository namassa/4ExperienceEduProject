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
                respawnMonsterCommand.Position = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
                break;
            case MonsterType.Ogre:
                respawnMonsterCommand.MonsterPrefab = ogre;
                respawnMonsterCommand.Position = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
                break;
            case MonsterType.Goblin:
                respawnMonsterCommand.MonsterPrefab = goblin;
                respawnMonsterCommand.Position = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
                break;
        }

        for (int i = 0; i < monster.count; i++)
        {
            respawnMonsterCommand.ExecuteCommand();
        }
    }
}