using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public int maxHunger;
    public int currentHunger;

    public int maxThirst;
    public int currentThirst;

    public float hungerBurn;
    public float thirstBurn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
