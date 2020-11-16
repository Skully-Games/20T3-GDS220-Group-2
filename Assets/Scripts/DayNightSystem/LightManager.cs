using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{
    public GameObject targetLight;
    public GameObject targetMainCamera;
    public Material[] sky;

    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreset Preset;

    [SerializeField, Range(0, 48)] private float TimeofDay;

    [SerializeField, Range(0, 5)] private float LightIntensity;

    private void Awake()
    {
        targetLight = GameObject.FindGameObjectWithTag("Light");
        targetMainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        LightIntensity = Mathf.Abs(targetLight.GetComponent<Light>().intensity);
    }
    void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeofDay += Time.deltaTime;
            TimeofDay %= 48;  // For longer period of time change the value
            UpdateLighting(TimeofDay / 48f);
        }
        else
        {
            UpdateLighting(TimeofDay / 48f);
        }

        if (TimeofDay <= 24f)
        {
            targetLight.GetComponent<Light>().intensity = LightIntensity += Time.deltaTime * 0.18f;
        }
        else if (TimeofDay <= 48f)
        {
            targetLight.GetComponent<Light>().intensity = LightIntensity -= Time.deltaTime * 0.18f;
        }

        ChangeCycle();
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

            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }

        }

    }
    void ChangeCycle()  //THIS FUNCTION IS FOR CHANGING THE SKYBOX AND NEEDS TO SETUP A SKYBOX IN MAIN CAMERA
    {
        if (TimeofDay >= 0.2f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[3];
        }

        if (TimeofDay >= 10.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[2];
        }

        if (TimeofDay >= 12.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[0];
        }

        if (TimeofDay >= 38.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[2];
        }

        if (TimeofDay >= 40.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[3];
        }

        if (TimeofDay >= 45.5f)
        {
            targetMainCamera.GetComponent<Skybox>().material = sky[1];
        }

    }

}
