using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private MonsterFactory _monsterFactory;

    private void Awake()
    {
        _monsterFactory = FindObjectOfType<MonsterFactory>();
    }

    public void SpawnMonsters(MonsterType monsterType)
    {
        _monsterFactory.RespawnMonster(monsterType);
    }
}