using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : EnemyUnit
{
    public Laser laserPrefab;

    private float cooldown = 2f;

    private float rangeAttack = 9f;

    private bool redyToAttack = false;

    void Start()
    {
        Initialized();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    protected override void MoveTowardsPlayer()
    {
        if (playerPos != null)
        {
            Vector3 plaPos = playerPos.transform.position;

            Vector3 enemyPos = transform.position;

            Vector3 direction = plaPos - enemyPos;

            if (direction.magnitude > 3f)
            {
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            transform.up = direction;

            if (direction.magnitude <= rangeAttack & redyToAttack == false)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    public override void DestroyEnemy()
    {
        GameManager.SendEnemyKilled();
        GameObject explosion = (GameObject)Instantiate(explosionEnemy);
        explosion.transform.localScale = new Vector2(2, 2);
        explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
        Destroy(gameObject);

        int randomBonus = Random.Range(0, 6);

        if (randomBonus == 1)
        {
            bonusHealth.SpawnBonusHealth(transform);
        }
    }

    public IEnumerator Shoot()
    {
        redyToAttack = true;
        while (true)
        {
            GameObject laserClon = Instantiate(laserPrefab.gameObject, transform.position + transform.up, transform.rotation);
            laserClon.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.56f, 1f, 0.2f);
            yield return new WaitForSeconds(cooldown);
        }
    }

}
