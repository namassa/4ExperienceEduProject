using UnityEngine;

public class InputController : MonoBehaviour
{
    private FactoryController _monsterFactoryController;

    private void Awake()
    {
        _monsterFactoryController = gameObject.AddComponent<FactoryController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _monsterFactoryController.SpawnMonsters(MonsterType.Orc);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _monsterFactoryController.SpawnMonsters(MonsterType.Ogre);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _monsterFactoryController.SpawnMonsters(MonsterType.Goblin);
        }
    }
}