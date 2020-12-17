using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class DeathCode : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        Debug.Log("Begin Anew");
    }

    public void QuitToMenu()
    {
        //Insert code here later
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Game has been quit.");
    }
}
