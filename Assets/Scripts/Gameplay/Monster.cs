using System.Collections;
using UnityEngine;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// class defines monster variables and methods
public class Monster : NPC
{
    public MonsterType monsterType;
    [SerializeField] public Character Character;
    private IEnumerator movingCoroutine;
    public Vector3 direction;

    private void Awake()
    {
        Collision = false;
        direction = MoveRandomlyTo(RandomizeDirection(""), Collision);
        movingCoroutine = Moving(gameObject, direction, Speed);
        StartCoroutine(movingCoroutine);
    }

    private Vector3 MoveRandomlyTo(Vector3 direction, bool collision)
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

    private Vector3 RandomizeDirection(string condition)
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

    private IEnumerator Moving(GameObject gameObject, Vector3 direction, float speed)
    {
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, speed * Time.deltaTime);
            yield return null;
        }
        direction = MoveRandomlyTo(RandomizeDirection(""), Collision);
        movingCoroutine = Moving(gameObject, direction, speed);
        StartCoroutine(movingCoroutine);
    }


    //mark as trigger
    private void OnTriggerEnter(Collider other)
    {
        Collision = true;

        if (tag == other.tag)
        {
            //SayHello();

            StopCoroutine(movingCoroutine);
            movingCoroutine = Moving(gameObject, direction, Speed);
            StartCoroutine(movingCoroutine);
        }
    }

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