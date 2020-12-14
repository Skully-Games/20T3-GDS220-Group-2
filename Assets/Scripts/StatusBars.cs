using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBars : MonoBehaviour
{
    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;

    public float healthValue;
    public float hungerValue;
    public float thirstValue;

    public void Update()
    {
        HealthChange(healthValue);
        HungerChange(hungerValue);
        ThirstChange(thirstValue);
    }

    public void HealthChange(float health)
    {
        float healthAmount = (health / 100.0f);
        healthBar.fillAmount = healthAmount;
    }

    public void HungerChange(float hunger)
    {
        float hungerAmount = (hunger / 100.0f);
        hungerBar.fillAmount = hungerAmount;
    }

    public void ThirstChange(float thirst)
    {
        float thirstAmount = (thirst / 100.0f);
        thirstBar.fillAmount = thirstAmount;
    }

    #region Old Code
    /*
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
    */
    #endregion
}
