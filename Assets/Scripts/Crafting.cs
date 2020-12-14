using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public GameObject boatCrafting;
    public GameObject pickaxeCrafting;
    public GameObject CraftingUI;

    public bool boatCrafted = false;
    public bool pickaxeCrafted = false;


    public PlayerInventory inventory;

    public void Update()
    {

        if (inventory.wood >= 10 && inventory.stone >= 5)
        {
            boatCrafting.SetActive(true);
        }

        else
        {
            boatCrafting.SetActive(false);
        }

        if (inventory.wood >= 2 && inventory.stone >= 1)
        {
            pickaxeCrafting.SetActive(true);
        }

        else
        {
            pickaxeCrafting.SetActive(false);
        }
    }

    public void CraftingBoat()
    {
            inventory.wood -= 10;
            inventory.stone -= 5;
            boatCrafted = true;
            Debug.Log("Boat Acquired!");
    }

    public void CraftingPickaxe()
    {
        inventory.wood -= 2;
        inventory.stone -= 1;
        pickaxeCrafted = true;
        Debug.Log("Pickaxe Acquired!");
    }

    public void CraftingOpen()
    {
        CraftingUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CraftingClose()
    {
        CraftingUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
