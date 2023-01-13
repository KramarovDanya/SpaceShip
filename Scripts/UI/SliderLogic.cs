using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLogic : MonoBehaviour
{
    
    bool isActiv = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenClose()
    {
        if (isActiv == false)
        {
            gameObject.SetActive(true);
            isActiv = true;
        }
        else
        {
            gameObject.SetActive(false);
            isActiv = false;
        }
    }
}
