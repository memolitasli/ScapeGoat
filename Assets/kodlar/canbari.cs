﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class canbari : MonoBehaviour
{
    public Slider slider;    
    public void setMaxHealth()
    {
        slider.maxValue = 100;
        slider.value = 100;
    }
    public void setHealth(int health)
    {
        slider.value = health;
    }
}
