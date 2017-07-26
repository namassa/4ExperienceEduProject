using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : NPC
{
    public CharacterType characterType;
    private IEnumerator movingCoroutine;
    private Vector3 direction;
    private List<Vector3> monstersPositions;

    private void Awake()
    {
        monstersPositions = new List<Vector3>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane") return;
        if (other.isTrigger && other.tag == "Monster")
        {
            Follow(other.GetComponent<Monster>().transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Plane") return;
        if (other.isTrigger && other.tag == "Monster")
        {
            Follow(other.GetComponent<Monster>().transform.position);
        }
    }

    private void Follow(Vector3 direction)
    {
        if(movingCoroutine != null)
            StopCoroutine(movingCoroutine);
        direction.y = 1f;
        movingCoroutine = Moving(gameObject, direction, Speed);
        StartCoroutine(movingCoroutine);
    }
    private IEnumerator Moving(GameObject gameObject, Vector3 direction, float speed)
    {
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direction, speed * Time.deltaTime);
            yield return null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            var monster = collision.gameObject.GetComponent<Monster>();

            GetDamageBy(monster);

            if (Health <= 0)
            {
                monster.Health = monster.Character.FullHP;
                Destroy(gameObject);
            }
        }
    }

    private void GetDamageBy(Monster monster)
    {
        Health -= monster.Damage;
        Debug.Log(gameObject.name + Health);
    }
    
}
