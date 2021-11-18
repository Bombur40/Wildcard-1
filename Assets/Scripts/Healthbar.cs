using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        if (health < 1) {
            throw new ArgumentOutOfRangeException("Max health must be a positive integer");
        }

        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = Mathf.Clamp(health, 0, slider.maxValue); // clamp it and make sure health is not less than 0 or greater than max
    }
}