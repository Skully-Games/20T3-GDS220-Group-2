using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNighController : MonoBehaviour
{

    /* OLD CODE FOR DAY AND NIGHT

    public GameObject targetLight;
    public GameObject targetMainCamera;
    public Material[] skys;
    public float dayTimer;
    public bool isCycled;
    private void Awake()
    {
        targetLight = GameObject.FindGameObjectWithTag("Light");
        targetMainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Start is called before the first frame update
    void Start()
    {
        dayTimer = targetLight.GetComponent<Light>().intensity;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCycled)
        {
            targetLight.GetComponent<Light>().intensity = dayTimer -= Time.deltaTime * 0.1f;

            if (dayTimer <= 0)
            {
                isCycled = true;              
            }
        }

        else if (isCycled)
        {
            targetLight.GetComponent<Light>().intensity = dayTimer += Time.deltaTime * 0.1f;

            if (dayTimer >= 1)
            {
                isCycled = false;              
            }
        }

        ChangeCycle();
        
    }
  
    void ChangeCycle()  //THIS FUNCTION IS FOR CHANGING THE SKYBOX AND NEEDS TO SETUP A SKYBOX IN MAIN CAMERA
    {
        if (dayTimer >= 0.9f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[0];
        }

        else if (dayTimer >= 0.1f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[1];
        }
    }

    */

   
}
