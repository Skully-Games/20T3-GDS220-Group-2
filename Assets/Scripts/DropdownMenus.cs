using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenus : MonoBehaviour
{
    public TMP_Dropdown woodDrop;
    public TMP_Dropdown stoneDrop;
    public TMP_Dropdown foodDrop;
    public TMP_Dropdown waterDrop;

    public int defaultElement = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        woodDrop.value = defaultElement;

    }
}
