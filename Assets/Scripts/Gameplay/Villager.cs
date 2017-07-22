using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : NPC
{
    public CharacterType characterType;
    private IEnumerator movingCoroutine;
    private Vector3 direction;
    private List<Vector3> monstersPositions;

    private void Awake()
    {
        Collision = false;
        RunAway();
    }

    private void RunAway()
    {
        throw new NotImplementedException();
    }

    private float GetMinimumDistance()
    {
        float minimumDistance = Mathf.Infinity;
        foreach (var monster in UIController.monsters)
        {
            monstersPositions.Add(monster.GetComponent<Monster>().transform.position);
        }
        foreach (var monsterPosition in monstersPositions)
        {
            float distance = Vector3.Distance(monsterPosition, transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
            }
        }
        return minimumDistance;
    }

    private IEnumerator Moving(GameObject gameObject, Vector3 direction, float speed)
    {
        while (gameObject.transform.position != direction)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, -direction, speed * Time.deltaTime);
            yield return null;
        }

        RunAway();

        ////direction = MoveRandomlyTo(RandomizeDirection(""), Collision);
        //movingCoroutine = Moving(gameObject, direction, speed);
        //StartCoroutine(movingCoroutine);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collision = true;
        if (other.tag == "Monster")
        {
            var monster = other.gameObject.GetComponent<Monster>();

            GetDamageBy(monster);

            if (Health <= 0)
            {
                monster.Health = monster.Character.FullHP;
                Destroy(gameObject);
            }
        }
        else if (other.tag != "Plane")
        {
            //Debug.Log("doing damage to enemy");
            //DoDamage(other);
        }
    }

    private void GetDamageBy(Monster monster)
    {
        Health -= monster.Damage;
        Debug.Log(gameObject.name + Health);
    }
}
