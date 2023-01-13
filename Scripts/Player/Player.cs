using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    public LaserBar healthBar;
    public LaserGunSpawner laserGunSpawner;

    public AudioSource healthSound;
    public AudioSource damageSound;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealthValue(currentHealth);
    }

    private void Update()
    {
        healthBar.SetCurrentHealthValue(currentHealth);
    }
    public void DestroyPlayer()
    {
        gameObject.SetActive(false);
        GameManager.SendPlayerKilled();
    }

    public void SpawnPlayer()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealthValue(currentHealth);
        gameObject.transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
        laserGunSpawner.SetAmmo();
    }

    public void TakeDamage(int damage)
    {
        damageSound.Play();
        currentHealth -= damage;
        healthBar.SetCurrentHealthValue(currentHealth);
        if (currentHealth <= 0)
        {
            DestroyPlayer();
        }
    }

    public void TakeHealth(float bonusHealth)
    {
        
        currentHealth += bonusHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        healthBar.SetCurrentHealthValue(currentHealth);
        healthSound.Play();
    }
}
