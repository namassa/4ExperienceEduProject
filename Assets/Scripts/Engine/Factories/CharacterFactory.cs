using UnityEngine;

// dsiemienik@gmail.com
// class set which prefab and where should be instantiated
public class CharacterFactory : MonoBehaviour
{
    public struct Character
    {
        public CharacterType CharacterType;
        public int Count;
    }

    [SerializeField] protected GameObject villager;
    [SerializeField] protected GameObject hero;

    GameObject characterGameObject;

    public void RespawnCharactersByType(Character character)
    {
        
        Vector3 position = Vector3.zero;

        switch (character.CharacterType)
        {
            case CharacterType.Hero:
                characterGameObject = hero;
                position = new Vector3(Random.Range(15, 20), 0.5f, Random.Range(-15, -20));
                break;
            case CharacterType.Villager:
                characterGameObject = villager;
                position = new Vector3(Random.Range(15, 20), 0.5f, Random.Range(-15, -20));
                break;
        }

        for (int i = 0; i < character.Count; i++)
        {
            Instantiate(characterGameObject, position, Quaternion.identity);
        }
    }
}