using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public Button pickaxe;
    public Button boat;
    public Image pickaxeImage;
    public Image boatImage;

    public GameObject CraftingUI;

    public bool boatCrafted = false;
    public bool pickaxeCrafted = false;


    public PlayerInventory inventory;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI crystalText;


    public void Update()
    {
        woodText.text = inventory.wood.ToString();
        stoneText.text = inventory.stone.ToString();
        crystalText.text = inventory.crystal.ToString();

        if (inventory.wood >= 10 && inventory.stone >= 5)
        {
            //boatCrafting.SetActive(true);
            CanCraftBoat();
        }
        else
        {
            //boatCrafting.SetActive(false);
            boat.interactable = false;
            boatImage.color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);
        }

        if (inventory.wood >= 2 && inventory.stone >= 1)
        {
            //pickaxeCrafting.SetActive(true);
            CanCraftPickaxe();
        }
        else
        {
            //pickaxeCrafting.SetActive(false);
            pickaxe.interactable = false;
            pickaxeImage.color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5019608f);
        }
    }

    void CanCraftBoat()
    {
        boat.interactable = true;
        boatImage.color = new Color(1, 1, 1, 1f);
    }

    void CanCraftPickaxe()
    {
        pickaxe.interactable = true;
        pickaxeImage.color = new Color(1f, 1f, 1f, 1f);
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
