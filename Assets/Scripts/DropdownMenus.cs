using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DropdownMenus : MonoBehaviour
{
    /*
    public TMP_Dropdown woodDrop;
    public TMP_Dropdown stoneDrop;
    public TMP_Dropdown foodDrop;
    public TMP_Dropdown waterDrop;

    public int defaultElement = 2;

    public PlayerInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        woodDrop.value = defaultElement;
        stoneDrop.value = defaultElement;
        foodDrop.value = defaultElement;
        waterDrop.value = defaultElement;
    }

    public void HandleInputDataWood(int val)
    {
        if (val == 0 && inventory.wood != 0)
        {
            DropWood();
        }
        else
        {
            woodDrop.value = defaultElement;
        }
    }

    public void HandleInputDataStone(int val)
    {
        if (val == 0)
        {
            DropStone();
        }
    }

    public void HandleInputDataFood(int val)
    {
        if (val == 0)
        {
            ConsumeFood();
        }

        if (val == 1)
        {
            DropFood();
        }
    }

    public void HandleInputDataWater(int val)
    {
        if (val == 0)
        {
            ConsumeWater();
        }

        if (val == 1)
        {
            DropWater();
        }
    }

    void DropWood()
    {
        Debug.Log("Dropped Wood");
        inventory.wood -= 1;
        woodDrop.value = defaultElement;
    }

    void DropStone()
    {
        Debug.Log("Dropped Stone");
        inventory.stone--;
        stoneDrop.value = defaultElement;
    }

    void DropFood()
    {
        Debug.Log("Dropped Food");
        inventory.food--;
        foodDrop.value = defaultElement;
    }

    void DropWater()
    {
        Debug.Log("Dropped Water");
        inventory.water--;
        waterDrop.value = defaultElement;
    }

    void ConsumeFood()
    {
        Debug.Log("Consumed Food");
        inventory.food--;
        foodDrop.value = defaultElement;
    }

    void ConsumeWater()
    {
        Debug.Log("Consumed Water");
        inventory.water--;
        waterDrop.value = defaultElement;
    }

    // Update is called once per frame
    void Update()
    {

    }
    */
}
