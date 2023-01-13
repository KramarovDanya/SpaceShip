using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 3f;
    
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<EnemyUnit>().DestroyEnemy();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(10);
            Destroy(gameObject);
        }
    }

    
}
