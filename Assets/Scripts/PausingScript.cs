using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingScript : MonoBehaviour
{
    public static bool BackpackToggle = false;

    public GameObject BackpackUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (BackpackToggle)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
    }

    void Resume()
    {
        BackpackUI.SetActive(false);
        Time.timeScale = 1f;
        BackpackToggle = false;
    }

    void Pause()
    {
        BackpackUI.SetActive(true);
        Time.timeScale = 0f;
        BackpackToggle = true;
    }
}
