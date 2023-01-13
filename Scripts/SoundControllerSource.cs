using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerSource : MonoBehaviour
{
    public AudioSource explosionSound;

    void Start()
    {
        GameManager.OnEnemyKilled += explosionSoun;
    }
   
    public void explosionSoun()
    {
        explosionSound.Play();
    }

    private void OnDestroy()
    {
        GameManager.OnEnemyKilled -= explosionSoun;
    }
}
