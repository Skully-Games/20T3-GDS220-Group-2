using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector]
    public int wood = 0;
    [HideInInspector]
    public int stone = 0;
    [HideInInspector]
    public int food = 0;
    [HideInInspector]
    public int crystal = 0;

    public float holdToMineTimer = 2f;
    public float holdToMineTimerElapsed;
    public Slider mineBar;
    public GameObject mineSlider;

    //Water Drinking
    public PlayerStats stats;
    public float drinkSpeed;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI pickUpMessage;

    public GameObject Interactable;
    public GameObject craftingUI;
    public Camera camera;

    public Crafting crafting;

    private ResorcePickup itemBeingPickedUp;

    void Update()
    {
        #region UI Stuff
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        foodText.text = food.ToString();
        crystalText.text = crystal.ToString();

        mineBar.maxValue = holdToMineTimer;
        mineBar.value = holdToMineTimerElapsed;

        if (wood > 999)
        {
            wood = 999;
        }

        if (stone > 999)
        {
            stone = 999;
        }

        if (food > 999)
        {
            food = 999;
        }

        if (crystal > 999)
        {
            crystal = 999;
        }
        #endregion

        SelectItemBeingPickedUpFromRay();

        if (HasItemTargetted())
        {
            pickUpMessage.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (itemBeingPickedUp.tag == "Wood")
                {
                    wood++;
                    Destroy(itemBeingPickedUp.gameObject);
                    itemBeingPickedUp = null;
                }
                else if (itemBeingPickedUp.tag == "Stone")
                {
                    stone++;
                    Destroy(itemBeingPickedUp.gameObject);
                    itemBeingPickedUp = null;
                }
                else if (itemBeingPickedUp.tag == "Food")
                {
                    food++;
                    Destroy(itemBeingPickedUp.gameObject);
                    itemBeingPickedUp = null;
                }
                else if (itemBeingPickedUp.tag == "CraftingTable")
                {
                    crafting.CraftingOpen();
                }
            }

            if (Input.GetButton("Fire1"))
            {
                if (itemBeingPickedUp.tag == "Crystal")
                {
                    mineSlider.gameObject.SetActive(true);
                    HoldToMineProgress();
                }
            }

            if (Input.GetKey(KeyCode.E))
            {
                if (itemBeingPickedUp.tag == "Water")
                {
                    stats.currentThirst += drinkSpeed * Time.deltaTime;
                }
            }
        }

        else
        {
            pickUpMessage.gameObject.SetActive(false);
            mineSlider.gameObject.SetActive(false);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            holdToMineTimerElapsed = 0f;
            mineSlider.gameObject.SetActive(false);
        }

    }

    private bool HasItemTargetted()
    {
        return itemBeingPickedUp != null;
    }

    private void HoldToMineProgress()
    {
        holdToMineTimerElapsed += Time.deltaTime;
        if (holdToMineTimerElapsed >= holdToMineTimer)
        {
            crystal++;
            Destroy(itemBeingPickedUp.gameObject);
            itemBeingPickedUp = null;
            mineSlider.gameObject.SetActive(false);
        }
    }

    private void SelectItemBeingPickedUpFromRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 4f))
        {
            var hitItem = hitInfo.collider.GetComponent<ResorcePickup>();

            if (hitItem == null)
            {
                itemBeingPickedUp = null;
            }
            else if (hitItem != null && hitItem != itemBeingPickedUp)
            {
                itemBeingPickedUp = hitItem;

                if (itemBeingPickedUp.tag != "Crystal" && itemBeingPickedUp.tag != "Water" && itemBeingPickedUp.tag != "CraftingTable")
                {
                    pickUpMessage.text = "Pick Up: " + itemBeingPickedUp.gameObject.name;
                }
                else if (itemBeingPickedUp.tag == "Crystal")
                {
                    pickUpMessage.text = "(Hold LMB) Mine Crystal";
                }
                else if (itemBeingPickedUp.tag == "Water")
                {
                    pickUpMessage.text = "(Hold E) Drink Water";
                }
                else if (itemBeingPickedUp.tag == "CraftingTable")
                {
                    pickUpMessage.text = "Open Crafting Menu";
                }

            }

        }
        else
        {
            itemBeingPickedUp = null;
        }
    }
}
