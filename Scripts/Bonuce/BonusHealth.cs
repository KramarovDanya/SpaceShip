using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : MonoBehaviour
{
    public float bonusHealth = 20f;

    private void Start()
    {
        Destroy(gameObject, 3f);
        GameManager.OnPlayerKilled += DestroyBounusHealth;
    }
    public void SpawnBonusHealth(Transform transform)
    {
        GameObject clonBonusHealth = Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeHealth(bonusHealth);
            Destroy(gameObject);
        }
    }

    private void DestroyBounusHealth()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.OnPlayerKilled -= DestroyBounusHealth;
    }
}
