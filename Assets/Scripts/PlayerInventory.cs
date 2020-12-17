using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //[HideInInspector]
    public int wood = 0;
    //[HideInInspector]
    public int stone = 0;
    //[HideInInspector]
    public int food = 0;
    //[HideInInspector]
    public int crystal = 0;

    //Hold2Mine Variables
    public float holdToMineTimer = 2f;
    public float holdToMineTimerElapsed;
    public Slider mineBar;
    public GameObject mineSlider;

    //Water Drinking
    public PlayerStats stats;
    public float drinkSpeed;

    //UI Variables
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI pickUpMessage;

    public GameObject Interactable;
    public GameObject craftingUI;
    public Camera camera;
    private ResorcePickup itemBeingPickedUp;

    //Crafting Variables
    public Crafting crafting;
    public bool pickaxeEquipped = false;

    //Pickaxe Tool Variables
    public GameObject pickaxeIcon;
    public Image pickaxeImage;
    public Color equipped;
    public Color unequipped;


    private void Start()
    {
        pickaxeImage = pickaxeIcon.GetComponent<Image>();
        equipped = new Color(pickaxeImage.color.r, pickaxeImage.color.g, pickaxeImage.color.b, 1f);
        unequipped = new Color(pickaxeImage.color.r, pickaxeImage.color.g, pickaxeImage.color.b, 0.1f);
    }

    void Update()
    {
        if (crafting.pickaxeCrafted == false)
        {
            pickaxeIcon.SetActive(false);
        }
        else
        {
            pickaxeIcon.SetActive(true);
        }

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
                    if (pickaxeEquipped == true)
                    {
                        mineSlider.gameObject.SetActive(true);
                        HoldToMineProgress();
                    }
                    else
                    {
                        Debug.Log("Needs a pickaxe equipped");
                    }
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

        if (Input.GetKeyDown(KeyCode.Q) && crafting.pickaxeCrafted == true && pickaxeEquipped == false)
        {
            EquipPickaxe();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && crafting.pickaxeCrafted == true && pickaxeEquipped == true)
        {
            UnequipPickaxe();
        }

        //Opening and Closing Map

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

    void EquipPickaxe()
    {
        pickaxeEquipped = true;
        pickaxeImage.color = equipped;
        Debug.Log("Pickaxe is Equipped");
    }

    void UnequipPickaxe()
    {
        pickaxeEquipped = false;
        pickaxeImage.color = unequipped;
        Debug.Log("Pickaxe is Unequipped");
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
                    pickUpMessage.text = "(E) Pick Up: " + itemBeingPickedUp.gameObject.name;
                }
                else if (itemBeingPickedUp.tag == "Crystal")
                {
                    if (pickaxeEquipped == true)
                    {
                        pickUpMessage.text = "(Hold LMB) Mine Crystal";
                    }
                    else
                    {
                        pickUpMessage.text = "Needs a Pickaxe";
                    }
                }
                else if (itemBeingPickedUp.tag == "Water")
                {
                    pickUpMessage.text = "(Hold E) Drink Water";
                }
                else if (itemBeingPickedUp.tag == "CraftingTable")
                {
                    pickUpMessage.text = "(E) Open Crafting Menu";
                }

            }

        }
        else
        {
            itemBeingPickedUp = null;
        }
    }
}
