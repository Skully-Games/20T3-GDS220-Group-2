using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
   // [HideInInspector]
    public int wood = 0;
   // [HideInInspector]
    public int stone = 0;

    public int food = 0;

    public int water = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI pickUpMessage;

    public GameObject Interactable;
    public GameObject craftingUI;
    public Camera camera;

    public Crafting crafting;
    public EndGame endGame;
    public PlayerMovement playerMovement;

    private ResorcePickup itemBeingPickedUp;

    void Update()
    {
        #region UI Stuff
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        foodText.text = food.ToString();
        waterText.text = water.ToString();

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

        if (water > 999)
        {
            water = 999;
        }
        #endregion

        SelectItemBeingPickedUpFromRay();

        if (HasItemTargetted())
        {
            pickUpMessage.gameObject.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
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
                else if (itemBeingPickedUp.tag == "Water")
                {
                    water++;
                    Destroy(itemBeingPickedUp.gameObject);
                    itemBeingPickedUp = null;
                }
                else if (itemBeingPickedUp.tag == "CraftingTable")
                {
                    crafting.CraftingOpen();
                }

                else if (itemBeingPickedUp.tag == "BoatDeploy")
                {
                    if (crafting.boatCrafted = true && playerMovement.isWatered)
                    {
                        endGame.GameEnd();
                    }
                }
            }
        }

        else
        {
            pickUpMessage.gameObject.SetActive(false);
        }


    }

    private bool HasItemTargetted()
    {
        return itemBeingPickedUp != null;
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
                pickUpMessage.text = "Pick Up: " + itemBeingPickedUp.gameObject.name;
            }

        }
        else
        {
            itemBeingPickedUp = null;
        }
    }

    #region Collision-based Collection
    /*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Wood")
        {
            Debug.Log("Player has collided with Wood");
            wood ++;
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.tag == "Stone")
        {
            Debug.Log("Player has collided with Stone");
            stone++;
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.tag == "Food")
        {
            Debug.Log("Player has collided with Food");
            food++;
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.tag == "Water")
        {
            Debug.Log("Player has collided with Water");
            water++;
            Destroy(hit.gameObject);
        }
    }
    */
    #endregion
}
