using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledText : MonoBehaviour
{
    public int killed;
    
    void Start()
    {
        GameManager.OnEnemyKilled += EnemyKilled;
    }
    
    public void EnemyKilled()
    {
        killed++;
        GetComponent<Text>().text = "SCORE: " + killed;
    }

    public void ReplayKilledText()
    {
        killed = 0;
        GetComponent<Text>().text = "SCORE: " + killed;
    }
    private void OnDestroy()
    {
        GameManager.OnEnemyKilled -= EnemyKilled;
    }

}
