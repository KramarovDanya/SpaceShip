using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnEnemyKilled;
    public static Action OnPlayerKilled;

    public static void SendEnemyKilled()
    {
        if (OnEnemyKilled != null) OnEnemyKilled.Invoke();
    }
    public static void SendPlayerKilled()
    {
        if (OnPlayerKilled != null) OnPlayerKilled.Invoke();
    }
}
