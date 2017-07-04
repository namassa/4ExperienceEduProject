using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour, IMonster {

    int _healthPoints;
    public int healthPoints
    {
        get
        {
            return this._healthPoints;
        }
        set
        {
            this._healthPoints = value;
        }
    }

    int _damage;
    public int damage
    {
        get
        {
            return this._damage;
        }
        set
        {
            this._damage = value;
        }
    }

    float _movementSpeed;
    public float movementSpeed
    {
        get
        {
            return this._movementSpeed;
        }
        set
        {
            this._movementSpeed = value;
        }
    }

    private void Awake()
    {
        healthPoints = 100;
        damage = 20;
        movementSpeed = 1f;
        MoveTo();
    }

    public void MoveTo()
    {
        Vector3 direction = RandomizeDirection();
        WhereAmIGoing(direction);
        StartCoroutine("Moving", direction);
    }

    private Vector3 RandomizeDirection()
    {
        return new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
    } 

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

    //mark as trigger
    private void OnTriggerEnter(Collider other)
    {
        if(this.tag != other.tag)
        {
            Debug.Log("doing damage to enemy");
            DoDamage(other);
        }
        else if(this.tag == other.tag)
        {
            SayHello();
        }
    }

    public void DoDamage(Collider other)
    {
        //deal damage to enemy
        other.gameObject.GetComponent<IMonster>().healthPoints -= _damage;
    }

    public void DoDamage()
    {

    }

    public void SayHello()
    {
        Debug.Log("Hello");
    }

    public void WhereAmIGoing()
    {
    }
}
