using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursorPriz : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = false;
        GameManager.OnPlayerKilled += PrizHide;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position -= new Vector3(0, 0, -9f);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PrizHide();
        }
    }

    public void PrizShow()
    {
        gameObject.SetActive(true);
        Cursor.visible = false;
    }
    public void PrizHide()
    {
        gameObject.SetActive(false);
        Cursor.visible = true;
    }
    private void OnDestroy()
    {
        GameManager.OnPlayerKilled -= PrizHide;
    }

}
