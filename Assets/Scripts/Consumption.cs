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
}
