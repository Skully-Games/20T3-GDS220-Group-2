using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void GameEnd()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None; 
        Debug.Log("You Win");
    }
}
