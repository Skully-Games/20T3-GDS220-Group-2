using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry : MonoBehaviour
{

    public GameObject journalEntry;
    // Start is called before the first frame update
    void Start()
    {
        JournalOpen();
        Cursor.lockState = CursorLockMode.None;
    }

    public void JournalClose()
    {
        journalEntry.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void JournalOpen()
    {
        journalEntry.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
