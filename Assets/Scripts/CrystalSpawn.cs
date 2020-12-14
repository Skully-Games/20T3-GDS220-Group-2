using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawn : MonoBehaviour
{
    public List<GameObject> crystals;
    public int chosenIndex;
    public GameObject chosenGameObject;
    public bool crystalSpawned;

    void Start()
    {
        
    }

    void Update()
    {
        chosenIndex = Random.Range(0, crystals.Count);
        Debug.Log(chosenIndex);

        if (Input.GetKeyDown(KeyCode.G))
        {
            chosenGameObject = crystals[chosenIndex];
            chosenGameObject.gameObject.SetActive(true);
        }

        //if (nightTime == true && crystalSpawned != true)
        //{
        //    SpawnCrystal();
        //}

        //if(nightTime != true && crystalSpawned == true)
        //{
        //    chosenGameObject.gameObject.SetActive(false);
        //}
    }

    //void SpawnCrystal()
    //{
    //    crystalSpawned = true;
    //    chosenGameObject = crystals[chosenIndex];
    //    chosenGameObject.gameObject.SetActive(true);
    //}

}
