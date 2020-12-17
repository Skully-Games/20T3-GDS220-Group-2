using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayNight_Manager
{

    //[ExecuteAlways]

    public class LightManager : MonoBehaviour
    {

        [Header("Day Music Score Controlls")]
        public AudioSource musicDaySource;
        [SerializeField, Range(0, 1)] private float musicVolumeDay;
        [Space(5)]

        [Header("Night Music Score Controlls")]
        public AudioSource musicNightSource;
        [SerializeField, Range(0, 1)] private float musicVolumeNight;
        [Space(5)]

        [Header("Ambience Day Controlls")]
        public AudioSource ambienceDaySource;
        [SerializeField, Range(0, 1)] private float ambienceVolumeDay;
        [Space(5)]

        [Header("Ambience Night Controlls")]
        public AudioSource ambienceNightSource;
        [SerializeField, Range(0, 1)] private float ambienceVolumeNight;
        [Space(5)]

        [Header("Game Object Source")]
        public GameObject targetLight;
        public GameObject targetMainCamera;
        [Space(5)]

        [Header("Skybox Source")]
        public Material[] sky;
        [Space(5)]

        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightPreset Preset;
        [Space(5)]

        [SerializeField, Range(0, 240)] private float TimeofDay;
        [SerializeField, Range(0, 5)] private float LightIntensity;

        private void Awake()
        {

            targetLight = GameObject.FindGameObjectWithTag("Light");
            targetMainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        }
        void Start()
        {
            LightIntensity = Mathf.Abs(targetLight.GetComponent<Light>().intensity);

            // ambience
            ambienceVolumeDay = ambienceDaySource.GetComponent<AudioSource>().volume;
            ambienceVolumeDay = 0.1f;

            ambienceVolumeNight = ambienceNightSource.GetComponent<AudioSource>().volume;
            ambienceVolumeNight = 1f;

            // music score
            musicVolumeDay = musicDaySource.GetComponent<AudioSource>().volume;
            musicVolumeDay = 0.1f;

            musicVolumeNight = musicNightSource.GetComponent<AudioSource>().volume;
            musicVolumeNight = 1f;
        }
        void Update()
        {
            if (Preset == null)
                return;

            if (Application.isPlaying)
            {
                TimeofDay += Time.deltaTime;
                TimeofDay %= 240;  // For longer period of time change the value
                UpdateLighting(TimeofDay / 240f);
            }
            else
            {
                UpdateLighting(TimeofDay / 240f);
            }


            if (TimeofDay <= 120f)
            {
                targetLight.GetComponent<Light>().intensity = LightIntensity += Time.deltaTime * 0.036f;

                ambienceDaySource.GetComponent<AudioSource>().volume = ambienceVolumeDay += Time.deltaTime * 0.008f;

                ambienceNightSource.GetComponent<AudioSource>().volume = ambienceVolumeNight -= Time.deltaTime * 0.008f;

                musicDaySource.GetComponent<AudioSource>().volume = musicVolumeDay += Time.deltaTime * 0.008f;

                musicNightSource.GetComponent<AudioSource>().volume = musicVolumeNight -= Time.deltaTime * 0.008f;

            }
            else if (TimeofDay <= 240f)
            {
                targetLight.GetComponent<Light>().intensity = LightIntensity -= Time.deltaTime * 0.036f;

                ambienceDaySource.GetComponent<AudioSource>().volume = ambienceVolumeDay -= Time.deltaTime * 0.008f;

                ambienceNightSource.GetComponent<AudioSource>().volume = ambienceVolumeNight += Time.deltaTime * 0.008f;

                musicDaySource.GetComponent<AudioSource>().volume = musicVolumeDay -= Time.deltaTime * 0.008f;

                musicNightSource.GetComponent<AudioSource>().volume = musicVolumeNight += Time.deltaTime * 0.008f;

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
            if (TimeofDay >= 1f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[3];
            }

            if (TimeofDay >= 52.5f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[2];
            }

            if (TimeofDay >= 62.5f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[0];
            }

            if (TimeofDay >= 192.5f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[2];
            }

            if (TimeofDay >= 202.5f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[3];
            }

            if (TimeofDay >= 227.5f)
            {
                targetMainCamera.GetComponent<Skybox>().material = sky[1];
            }

        }

    }
}


