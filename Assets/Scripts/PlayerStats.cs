using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float maxHunger;
    public float currentHunger;

    public float maxThirst;
    public float currentThirst;

    public float healthBurnRate = 1.5f;
    public float hungerBurnRate;
    public float thirstBurnRate;

    public StatusBars statBars;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;

        statBars.SetMaxHealth(maxHealth);
        statBars.SetMaxHunger(maxHunger);
        statBars.SetMaxThirst(maxThirst);
    }

    // Update is called once per frame
    void Update()
    {
        currentHunger -= (Time.deltaTime / hungerBurnRate);
        currentThirst -= (Time.deltaTime / thirstBurnRate);

        statBars.SetHealth(currentHealth);
        statBars.SetHunger(currentHunger);
        statBars.SetThirst(currentThirst);

        // Checks if Player health can regenerate
        if(currentHealth < maxHealth && currentHunger > 0 && currentThirst > 0)
        {
            currentHealth += (Time.deltaTime / healthBurnRate);
        }

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHunger >= maxHunger)
        {
            currentHunger = maxHunger;
        }

        if (currentHunger <= 0)
        {
            currentHunger = 0;
            Starvation();
        }

        if(currentThirst >= maxThirst)
        {
            currentThirst = maxThirst;
        }

        if (currentThirst <= 0)
        {
            currentThirst = 0;
            Dehydration();
        }

        if(currentHunger <= 0 && currentThirst <= 0)
        {
            DoubleDeath();
        }
    }


    #region Death Methods
    void Starvation()
    {
        if (currentThirst > 0)
        {
            currentHealth -= (Time.deltaTime / healthBurnRate);
        }
        else
        {
            DoubleDeath();
        }
    }

    void Dehydration()
    {
        if(currentHunger > 0)
        {
            currentHealth -= (Time.deltaTime / healthBurnRate);
        }
        else
        {
            DoubleDeath();
        }
    }

    void DoubleDeath()
    {
        healthBurnRate = 0.75f;
        currentHealth -= (Time.deltaTime / healthBurnRate);
    }

    #endregion
}
