using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private MonsterFactory _monsterFactory;
    private CharacterFactory _characterFactory;

    private void Awake()
    {
        _monsterFactory = GetComponentInChildren<MonsterFactory>();
        _characterFactory = GetComponentInChildren<CharacterFactory>();
    }

    public void RespawnMonsterByType(MonsterType monsterType, int count)
    {
        _monsterFactory.RespawnMonsterByType(monsterType, count);
    }
    public void RespawnCharacterByType(CharacterTypes characterType, int count)
    {
        _characterFactory.RespawnCharacterByType(characterType, count);
    }
}