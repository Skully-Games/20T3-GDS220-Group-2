using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBars : MonoBehaviour
{
    public Slider healthSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;

    //Health Status Bar//
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    //Hunger Status Bar//
    public void SetMaxHunger(float hunger)
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
    }

    public void SetHunger(float hunger)
    {
        hungerSlider.value = hunger;
    }

    //Thirst Status Bar//
    public void SetMaxThirst(float health)
    {
        thirstSlider.maxValue = health;
        thirstSlider.value = health;
    }

    public void SetThirst(float thirst)
    {
        thirstSlider.value = thirst;
    }
}
