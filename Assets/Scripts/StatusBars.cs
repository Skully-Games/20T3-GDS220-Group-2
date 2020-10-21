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
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    //Hunger Status Bar//
    public void SetMaxHunger(int hunger)
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;
    }

    public void SetHunger(int hunger)
    {
        hungerSlider.value = hunger;
    }

    //Thirst Status Bar//
    public void SetMaxThirst(int health)
    {
        thirstSlider.maxValue = health;
        thirstSlider.value = health;
    }

    public void SetThirst(int thirst)
    {
        thirstSlider.value = thirst;
    }
}
