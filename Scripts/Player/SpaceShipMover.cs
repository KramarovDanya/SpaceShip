using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMover : MonoBehaviour
{
    public int speed = 5;
    void FixedUpdate()
    {
        float ver = Input.GetAxis("Vertical");

        transform.position += Vector3.up * ver * Time.fixedDeltaTime * speed;

        float hor = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * hor * Time.fixedDeltaTime * speed;
    }
}
