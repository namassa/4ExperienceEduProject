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

    public void RespawnMonstersByType(MonsterType monsterType, int count)
    {
        MonsterFactory.Monster monster;
        monster.MonsterType = monsterType;
        monster.Count = count;
        _monsterFactory.RespawnMonstersByType(monster);
    }

    public void RespawnCharactersByType(CharacterType characterType, int count)
    {
        CharacterFactory.Character character;
        character.CharacterType = characterType;
        character.Count = count;
        _characterFactory.RespawnCharactersByType(character);
    }
}