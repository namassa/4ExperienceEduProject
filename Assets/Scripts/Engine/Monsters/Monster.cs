using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //Every creature must have some hp points
    int _healthPoints;
    public int healthPoints
    {
        get
        {
            return _healthPoints;
        }
        set
        {
            _healthPoints = value;
        }
    }

    //How many damage moster can deal
    int _damage;
    public int damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    //Each monster must have some value to know how fast change their position
    float _movementSpeed;
    public float movementSpeed
    {
        get
        {
            return _movementSpeed;
        }
        set
        {
            _movementSpeed = value;
        }
    }

    private void Awake()
    {
        healthPoints = 50;
        damage = 10;
        movementSpeed = 2f;
        MoveTo();
    }

    //method which moving the object to random position
    public void MoveTo()
    {
        Vector3 direction = RandomizeDirection();
        WhereAmIGoing(direction);
        StartCoroutine(Moving(direction));
    }

    private Vector3 RandomizeDirection()
    {
        return new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
    }

    //function tell us where monster is moving at present
    public void WhereAmIGoing(Vector3 direction)
    {
        Debug.Log("i'm going to " + direction.x + " " + direction.y + " " + direction.z);
    }

    IEnumerator Moving(Vector3 direction)
    {
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, direction, 0.1f * _movementSpeed);
            yield return null;
        }
        MoveTo();
    }

    //mark is trigger
    private void OnTriggerEnter(Collider other)
    {
        if (tag != other.tag && other.tag != "Plane")
        {
            Debug.Log("doing damage to enemy");
            DoDamage(other);
        }
        else if (tag == other.tag)
        {
            SayHello();
        }
    }

    //method calls only if enter enemy collider and dealing damage
    public void DoDamage(Collider other)
    {
        //deal damage to enemy
        other.gameObject.GetComponent<Monster>().healthPoints -= _damage;
    }

    //public void SayHello(Collider other)
    //{
    //    Debug.Log("Hello");
    //}

    //method calls only if enter friend collider and saying hello
    public void SayHello()
    {
        Debug.Log("Hello");
    }
}
