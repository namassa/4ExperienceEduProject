using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField] Move move;
    public Vector3 direction;
    public IEnumerator movingCoroutine;

    //method which moving the object to random position
    public void MoveRandomlyTo(GameObject gameObject, Vector3 direction, float movementSpeed, bool collision)
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
        }
        else
        {
            this.direction = RandomizeDirection("");
        }
        collision = false;
        movingCoroutine = move.Moving(this, gameObject, this.direction, movementSpeed, collision);
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
}