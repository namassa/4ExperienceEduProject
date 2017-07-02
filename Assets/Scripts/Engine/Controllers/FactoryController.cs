using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private MonsterFactory _monsterFactory;

    private void Awake()
    {
        _monsterFactory = FindObjectOfType<MonsterFactory>();
    }

    public void RespawnMonsterByType(MonsterType monsterType)
    {
        _monsterFactory.RespawnMonsterByType(monsterType);
    }
}