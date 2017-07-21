using UnityEngine;

public class InputController : MonoBehaviour
{
    protected FactoryController _factoryController;
    [SerializeField] protected int numberOfMonstersToRespawn = 1;

    private void Awake()
    {
        _factoryController = gameObject.AddComponent<FactoryController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _factoryController.RespawnMonsterByType(MonsterType.Orc, numberOfMonstersToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _factoryController.RespawnMonsterByType(MonsterType.Ogre, numberOfMonstersToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _factoryController.RespawnMonsterByType(MonsterType.Goblin, numberOfMonstersToRespawn);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            _factoryController.RespawnCharacterByType(CharacterTypes.Hero, numberOfMonstersToRespawn);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _factoryController.RespawnCharacterByType(CharacterTypes.Villager, numberOfMonstersToRespawn);
        }
    }
}