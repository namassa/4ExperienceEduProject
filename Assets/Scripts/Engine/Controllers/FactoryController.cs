using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private MonsterFactory _monsterFactory;

    private void Awake()
    {
        _monsterFactory = GetComponentInChildren<MonsterFactory>();
    }

    public void RespawnMonsterByType(MonsterType monsterType, int count)
    {
        _monsterFactory.RespawnMonsterByType(monsterType, count);
    }
}