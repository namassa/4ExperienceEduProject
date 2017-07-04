using UnityEngine;

public class InputController : MonoBehaviour
{
    private FactoryController _monsterFactoryController;
    [SerializeField] private int numberOfMonstersToRespawn = 1;

    private void Awake()
    {
        _monsterFactoryController = gameObject.AddComponent<FactoryController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _monsterFactoryController.RespawnMonsterByType(MonsterType.Orc, numberOfMonstersToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _monsterFactoryController.RespawnMonsterByType(MonsterType.Ogre, numberOfMonstersToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _monsterFactoryController.RespawnMonsterByType(MonsterType.Goblin, numberOfMonstersToRespawn);
        }
    }
}