using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public struct Monster
    {
        public MonsterType MonsterType;
        public int Count;
    }

    [SerializeField] private GameObject orc;
    [SerializeField] private GameObject ogre;
    [SerializeField] private GameObject goblin;

    GameObject monsterGameObject;

    public void RespawnMonstersByType(Monster monster)
    {
        Vector3 position = Vector3.zero;

        switch (monster.MonsterType)
        {
            case MonsterType.Orc:
                monsterGameObject = orc;
                position = new Vector3(Random.Range(-20, -15), 0.5f, Random.Range(15, 20));
                break;
            case MonsterType.Ogre:
                monsterGameObject = ogre;
                position = new Vector3(Random.Range(-20, -15), 0.5f, Random.Range(15, 20));
                break;
            case MonsterType.Goblin:
                monsterGameObject = goblin;
                position = new Vector3(Random.Range(-20, -15), 0.5f, Random.Range(15, 20));
                break;
        }

        for (int i = 0; i < monster.Count; i++)
        {
            Instantiate(monsterGameObject, position, Quaternion.identity);
            UIController.monsters.Add(monsterGameObject);
        }
    }
}