using System.Collections;
using UnityEngine;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// class defines monster variables and methods
public class Monster : NPC
{
    public MonsterType monsterType;
    public IEnumerator movingCoroutine;

    public void Awake()
    {
        collision = false;
        StartCoroutine(Moving(gameObject, MoveRandomlyTo(RandomizeDirection(""), collision), movementSpeed));
    }

    public Vector3 MoveRandomlyTo(Vector3 direction, bool collision)
    {
        string condition;
        if (collision)
        {
            if (direction.x > 0)
            {
                condition = "x+";
                return RandomizeDirection(condition);
            }
            if (direction.z > 0)
            {
                condition = "z+";
                return RandomizeDirection(condition);
            }
            if (direction.x < 0)
            {
                condition = "x-";
                return RandomizeDirection(condition);
            }
            if (direction.z < 0)
            {
                condition = "z-";
                return RandomizeDirection(condition);
            }
        }
        else
        {
            return RandomizeDirection("");
        }
        return Vector3.zero;
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

    public IEnumerator Moving(GameObject gameObject, Vector3 direction, float movementSpeed)
    {
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, movementSpeed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(Moving(gameObject, MoveRandomlyTo(RandomizeDirection(""), collision), movementSpeed));
    }

    ////function tell us where monster is moving at present
    //public void WhereAmIGoing(Vector3 direction)
    //{
    //    Debug.Log("i'm going to " + direction.x + " " + direction.y + " " + direction.z);
    //}


    ////mark as trigger
    //private void OnTriggerEnter(Collider other)
    //{
    //    collision = true;
    //    if (tag == other.tag)
    //    {
    //        SayHello();

    //        StopCoroutine(moveRandomly.movingCoroutine);
    //        //moveRandomly.MoveRandomlyTo(gameObject, moveRandomly.direction, _movementSpeed, collision);

    //        //CollisionCommand collisionCommand = GetComponent<CollisionCommand>();
    //        //collisionCommand.ExecuteCommand();
    //    }
    //    else if (other.tag != "Plane")
    //    {
    //        Debug.Log("doing damage to enemy");
    //        DoDamage(other);
    //    }
    //}

    ////method calls only if enter enemy collider and dealing damage
    //public void DoDamage(Collider other)
    //{
    //    //deal damage to enemy
    //    other.gameObject.GetComponent<Monster>().health -= damage;
    //}

    ////method calls only if enter friend collider and saying hello
    //public void SayHello()
    //{
    //    Debug.Log("Hello");
    //}

    //method which moving the object to random position
}