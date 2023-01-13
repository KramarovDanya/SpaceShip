using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDirection : MonoBehaviour
{
    

    
    void Update()
    {
        Vector2 playerPos = transform.position;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = playerPos - mousePos;

        transform.up = -direction;

    }
}
