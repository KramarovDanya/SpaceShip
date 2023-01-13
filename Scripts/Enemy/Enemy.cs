using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyUnit
{
    void Start()
    {
        Initialized();
    }
    
    void Update()
    {
        MoveTowardsPlayer();
    }
}
