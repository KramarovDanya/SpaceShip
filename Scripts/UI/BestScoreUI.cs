using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    [SerializeField] private KilledText killedText;

    private int bestScore;

    private void Start()
    {
        GetComponent<Text>().text = "BEST SCORE: " + PlayerPrefs.GetInt("bestScore", 0).ToString();
    }


    // Update is called once per frame
    void Update()
    {
        bestScore = killedText.killed;
        if (bestScore > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", bestScore);
            GetComponent<Text>().text = "BEST SCORE: " + bestScore;
        }
    }
}
