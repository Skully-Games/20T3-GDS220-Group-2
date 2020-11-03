using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    public GameObject targetLight;
    public GameObject targetMainCamera;
    public Material[] skys;

    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreset Preset;

    [SerializeField, Range(0, 24)] private float TimeofDay;

    [SerializeField, Range(0, 5)] private float dayTimer;

    private void Awake()
    {
        targetLight = GameObject.FindGameObjectWithTag("Light");
        targetMainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        dayTimer = Mathf.Abs(targetLight.GetComponent<Light>().intensity);
    }
    void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeofDay += Time.deltaTime;
            TimeofDay %= 24;
            UpdateLighting(TimeofDay / 24f);
        }
        else
        {
            UpdateLighting(TimeofDay / 24f);
        }

        if (TimeofDay <= 12f)
        {
            targetLight.GetComponent<Light>().intensity = dayTimer += Time.deltaTime * 0.4f;
        }
        else if (TimeofDay <= 24f)
        {
            targetLight.GetComponent<Light>().intensity = dayTimer -= Time.deltaTime * 0.4f;
        }

        ChangeCycle();

        OtherCycle();
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
        
            return;

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();

            foreach(Light light in lights)
            {
                if(light.type==LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
           
        }
        
    }
    void ChangeCycle()  //THIS FUNCTION IS FOR CHANGING THE SKYBOX AND NEEDS TO SETUP A SKYBOX IN MAIN CAMERA
    {
        if (TimeofDay >= 7f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[0];
        }

        else if (TimeofDay >= 0.2f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[1];
        }

    }

    void OtherCycle()  //THIS FUNCTION IS FOR CHANGING THE SKYBOX AND NEEDS TO SETUP A SKYBOX IN MAIN CAMERA
    {
        if (TimeofDay >= 20f)
        {
            targetMainCamera.GetComponent<Skybox>().material = skys[1];
        }

    }

}
