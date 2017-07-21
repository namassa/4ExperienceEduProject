using UnityEngine;

// dsiemienik@gmail.com
// class set which prefab and where should be instantiated
public class CharacterFactory : MonoBehaviour
{
    public struct Character
    {
        public CharacterTypes characterType;
        public int count;
    }

    [SerializeField] protected GameObject villager;
    [SerializeField] protected GameObject hero;

    public void RespawnCharacterByType(CharacterTypes characterType, int count)
    {
        var respawnCharacterCommand = GetComponent<RespawnCharacterCommand>();

        Character character;
        character.characterType = characterType;
        character.count = count;

        switch (character.characterType)
        {
            case CharacterTypes.Hero:
                respawnCharacterCommand.CharacterPrefab = hero;
                respawnCharacterCommand.Position = new Vector3(Random.Range(15, 20), 0.5f, Random.Range(-15, -20));
                break;
            case CharacterTypes.Villager:
                respawnCharacterCommand.CharacterPrefab = villager;
                respawnCharacterCommand.Position = new Vector3(Random.Range(15, 20), 0.5f, Random.Range(-15, -20));
                break;
        }

        for (int i = 0; i < character.count; i++)
        {
            respawnCharacterCommand.ExecuteCommand();
        }
    }
}