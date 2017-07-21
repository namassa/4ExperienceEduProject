using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// class defines monster variables and methods
public class Monster : MonoBehaviour
{
    //[SerializeField] Character character;
    public MonsterType monsterType;
    //Every creature must have some hp points
    [SerializeField] int _healthPoints;

    //How many damage moster can deal
    [SerializeField] int _damage;
    MoveRandomly moveRandomly;
    //Each monster must have some value to know how fast change their position
    [SerializeField] float _movementSpeed;
    public bool collision;

    public void Awake()
    {
        //healthPoints = 50;
        //damage = 10;
        //movementSpeed = 2f;
        collision = false;
        moveRandomly = GetComponent<MoveRandomly>();
        moveRandomly.MoveRandomlyTo(this.gameObject, moveRandomly.direction, _movementSpeed, collision);
    }

    //function tell us where monster is moving at present
    public void WhereAmIGoing(Vector3 direction)
    {
        Debug.Log("i'm going to " + direction.x + " " + direction.y + " " + direction.z);
    }


    //mark as trigger
    private void OnTriggerEnter(Collider other)
    {
        collision = true;
        if (tag == other.tag)
        {
            SayHello();

            StopCoroutine(moveRandomly.movingCoroutine);
            //moveRandomly.MoveRandomlyTo(gameObject, moveRandomly.direction, _movementSpeed, collision);

            //CollisionCommand collisionCommand = GetComponent<CollisionCommand>();
            //collisionCommand.ExecuteCommand();
        }
        else if (other.tag != "Plane")
        {
            Debug.Log("doing damage to enemy");
            DoDamage(other);
        }
    }

    //method calls only if enter enemy collider and dealing damage
    public void DoDamage(Collider other)
    {
        //deal damage to enemy
        other.gameObject.GetComponent<Monster>()._healthPoints -= _damage;
    }

    //method calls only if enter friend collider and saying hello
    public void SayHello()
    {
        Debug.Log("Hello");
    }
}
