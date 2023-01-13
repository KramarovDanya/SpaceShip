using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    
    void Start()
    {
        GameManager.OnPlayerKilled += PlayerKilled;
        gameObject.SetActive(false);
        
    }

    public void PlayerKilled()
    {
        gameObject.SetActive(true);
    }

    public void ReplayGameOverUI()
    {
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        GameManager.OnPlayerKilled -= PlayerKilled;
    }
}
