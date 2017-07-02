using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] protected GameObject orc;
    [SerializeField] protected GameObject ogre;
    [SerializeField] protected GameObject goblin;

    public void RespawnMonsterByType(MonsterType monsterType)
    {
        var respawnMonsterCommand = FindObjectOfType<RespawnMonsterCommand>();
        switch (monsterType)
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
        respawnMonsterCommand.Execute();
    }
}