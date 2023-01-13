using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemySniper enemySniper;
    [SerializeField] private Player playerPos;
    public float coolDown = 3f;

    
    void Start()
    {
        StartCoroutine(spawnEnemy());
        GameManager.OnPlayerKilled += StopSpawner;
    }

    private IEnumerator spawnEnemy()
    {
        while (playerPos != null)
        {
            float randDistance = Random.Range(10, 25);
            float randDir = Random.Range(0, 360);
            
            float posX = playerPos.transform.position.x + (Mathf.Cos(randDir * Mathf.Deg2Rad) * randDistance);
            float posY = playerPos.transform.position.y + (Mathf.Sin(randDir * Mathf.Deg2Rad) * randDistance);

            int randSpawnEnemy = Random.Range(1, 5);
            if (randSpawnEnemy == 1)
            {
                GameObject spawnedEnemy = Instantiate(enemySniper.gameObject, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            else
            {
                GameObject spawnedEnemy = Instantiate(enemy.gameObject, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(coolDown);
        }
        
    }

    private void StopSpawner()
    {
        gameObject.SetActive(false);
    }
    public void StartSpawner()
    {
        gameObject.SetActive(true);
        StartCoroutine(spawnEnemy());
    }
    private void OnDestroy()
    {
        GameManager.OnPlayerKilled -= StopSpawner;
    }

}
