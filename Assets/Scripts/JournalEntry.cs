using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry : MonoBehaviour
{

    public GameObject journalEntry;
    public GameObject statusBars;
    public GameObject crosshair;
    public GameObject pickupMessage;
    // Start is called before the first frame update
    void Start()
    {
        JournalOpen();
    }

    public void JournalClose()
    {
        journalEntry.SetActive(false);
        statusBars.SetActive(true);
        crosshair.SetActive(true);
        pickupMessage.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void JournalOpen()
    {
        journalEntry.SetActive(true);
        statusBars.SetActive(false);
        crosshair.SetActive(false);
        pickupMessage.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
