using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealthValue(float maxlaserValue)
    {
        slider.maxValue = maxlaserValue;
        slider.value = maxlaserValue;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetCurrentHealthValue(float laserValue)
    {
        slider.value = laserValue;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
