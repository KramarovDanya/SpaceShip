using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public float speed { get; set; }
    public float health { get; set; }

    public float Damage { get; set; }

    public void spawnUnit(Vector2 position)
    {
        GameObject unit = Instantiate(gameObject, position, Quaternion.identity);
    }

    public void destroyUnit(float timeWhenDestroy)
    {
        Destroy(gameObject, timeWhenDestroy);
    }

    public void moveUnit(Vector2 direction, float speed)
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
