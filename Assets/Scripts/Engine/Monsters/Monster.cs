using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// class defines monster variables and methods
public class Monster : MonoBehaviour
{
    public MonsterType monsterType;
    //Every creature must have some hp points
    [SerializeField] int _healthPoints;

    //How many damage moster can deal
    [SerializeField] int _damage;

    //Each monster must have some value to know how fast change their position
    [SerializeField] float _movementSpeed;

    public IEnumerator movingCoroutine;
    public Vector3 direction;
    public bool collision;

    public void Awake()
    {
        //healthPoints = 50;
        //damage = 10;
        //movementSpeed = 2f;
        collision = false;
        MoveCommand moveCommand = GetComponent<MoveCommand>();
        moveCommand.monster = this;
        moveCommand.ExecuteCommand();
    }

    //method which moving the object to random position
    public void MoveTo(Vector3 direction, bool collision)
    {
        Vector3 temp = new Vector3(0.0f, 0.5f, 0.0f);
        string condition;
        if (collision)
        {
            if (direction.x > 0)
            {
                condition = "x+";
                temp = RandomizeDirection(condition);
            }
            if (direction.z > 0)
            {
                condition = "z+";
                temp = RandomizeDirection(condition);
            }
            if (direction.x < 0)
            {
                condition = "x-";
                temp = RandomizeDirection(condition);
            }
            if (direction.z < 0)
            {
                condition = "z-";
                temp = RandomizeDirection(condition);
            }

            this.direction = temp;
            this.direction.y = 0.5f;


            //this.direction.x = -direction.x;
            //this.direction.z = -direction.z;
            //this.direction = new Vector3(-direction.x, 0.5f, -direction.z);
        }
        else
        {
            this.direction = RandomizeDirection("");
        }
        collision = false;
        //WhereAmIGoing(direction);
        movingCoroutine = Moving(this.direction);
        StartCoroutine(movingCoroutine);
    }

    public Vector3 RandomizeDirection(string condition)
    {
        switch (condition)
        {
            case "x-":
                return new Vector3(Random.Range(0, 20), 0.5f, Random.Range(-20, 20));
            case "z-":
                return new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(0, 20));
            case "x+":
                return new Vector3(Random.Range(-20, 0), 0.5f, Random.Range(-20, 20));
            case "z+":
                return new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 0));
        }
        return new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
    }

    //function tell us where monster is moving at present
    public void WhereAmIGoing(Vector3 direction)
    {
        Debug.Log("i'm going to " + direction.x + " " + direction.y + " " + direction.z);
    }

    public IEnumerator Moving(Vector3 direction)
    {
        while (gameObject.transform.position != direction)
        {

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, _movementSpeed * Time.deltaTime);
            //var velocity = 0.1f * _movementSpeed;
            //float x = Mathf.SmoothDamp(gameObject.transform.position.x, direction.x, ref velocity, 0.3f);
            //float z = Mathf.SmoothDamp(gameObject.transform.position.z, direction.z, ref velocity, 0.3f);
            //gameObject.transform.position = new Vector3(x, 0.5f, z);
            yield return null;
        }

        MoveCommand moveCommand = GetComponent<MoveCommand>();
        moveCommand.monster = this;
        moveCommand.ExecuteCommand();
    }

    //mark is trigger
    private void OnTriggerEnter(Collider other)
    {
        collision = true;
        if (tag == other.tag)
        {
            SayHello();
            StopCoroutine(movingCoroutine);
            MoveCommand moveCommand = GetComponent<MoveCommand>();
            moveCommand.monster = this;
            moveCommand.ExecuteCommand();
            CollisionCommand collisionCommand = GetComponent<CollisionCommand>();
            collisionCommand.ExecuteCommand();
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
