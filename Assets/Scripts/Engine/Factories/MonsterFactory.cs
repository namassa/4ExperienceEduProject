using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] protected GameObject orc;
    [SerializeField] protected GameObject ogre;
    [SerializeField] protected GameObject goblin;

    public void RespawnMonster(MonsterType monsterType)
    {
        var respawnMonsterCommand = FindObjectOfType<RespawnMonsterCommand>();
        respawnMonsterCommand.monsterType = monsterType;
        respawnMonsterCommand.Execute();
    }
}