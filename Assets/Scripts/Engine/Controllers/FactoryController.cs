using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private MonsterFactory _monsterFactory;

    private void Awake()
    {
        _monsterFactory = GetComponentInChildren<MonsterFactory>();
    }

    public void RespawnMonstersByType(MonsterType monsterType, int count)
    {
        MonsterFactory.Monster monster;
        monster.MonsterType = monsterType;
        monster.Count = count;
        _monsterFactory.RespawnMonstersByType(monster);
    }
}