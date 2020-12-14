using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Consumption : MonoBehaviour
{
    public PlayerInventory inventoryStats;
    public PlayerStats stats;

    public void ConsumeFood()
    {
        if (inventoryStats.food > 0)
        {
            inventoryStats.food --;
            stats.currentHunger += 20;
            Debug.Log("Consumed Food");
        }
        else
        {
            Debug.Log("Out of Food");
        }
    }

    public void ConsumeWater()
    {
        if (inventoryStats.water > 0)
        {
            inventoryStats.water --;
            stats.currentThirst += 20;
            Debug.Log("Consumed Water");
        }
        else
        {
            Debug.Log("Out of Water");
        }
    }
}
