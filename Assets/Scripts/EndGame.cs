using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject endGameScreen;
    public GameObject PlayerCharacter;

    public Crafting crafting;
    public PlayerMovement playerMovement;

    public bool inWater;

    public void Update()
    {
        if (crafting.boatCrafted && playerMovement.isWatered)
        {
            endGameScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None; 
        Debug.Log("You Win");
    }

    public void KeepExploring()
    {
        PlayerCharacter.transform.position = new Vector3(41.499f, 17.007f, 301.072f);
        endGameScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
