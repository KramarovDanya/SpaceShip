using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public Player playerPos;

    [SerializeField] protected BonusHealth bonusHealth;
    public float speed = 2f;
    public int damage = 20;
    public Object explosionEnemy;

    void Start()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }
    protected void Initialized()
    {
        playerPos = FindObjectOfType<Player>();
        GameManager.OnPlayerKilled += CleanGameEnemy;
        explosionEnemy = Resources.Load("explosionEnemy");
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (playerPos != null)
        {
            Vector3 plaPos = playerPos.transform.position;

            Vector3 enemyPos = transform.position;

            Vector3 direction = plaPos - enemyPos;

            transform.position += direction.normalized * speed * Time.deltaTime;

            transform.up = direction;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            DestroyEnemy();
        }
    }

    public virtual void DestroyEnemy()
    {
        GameManager.SendEnemyKilled();
        GameObject explosion = (GameObject)Instantiate(explosionEnemy);
        explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
        Destroy(gameObject);

        int randomBonus = Random.Range(0, 6);

        if (randomBonus == 1)
        {
            bonusHealth.SpawnBonusHealth(transform);
        }
    }
    protected void CleanGameEnemy()
    {
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        GameManager.OnPlayerKilled -= CleanGameEnemy;
    }
}
