using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    [SerializeField] private Light moon;
    [SerializeField] private float secondsInFullDay = 240f;

    [Range(0, 1)]
    [SerializeField] private float currentTimeOfNight = 0.5f;
    private float timeMultiplier = 1f;
    private float moonInitialIntensity;

    void Start()
    {
        moonInitialIntensity = moon.intensity;
    }

    void Update()
    {
        UpdateMoon();

        currentTimeOfNight += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfNight >= 1)
        {
            currentTimeOfNight = 0;
        }
    }


    void UpdateMoon()
    {
        moon.transform.localRotation = Quaternion.Euler((currentTimeOfNight * 360) - 90, 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfNight <= 0.23f || currentTimeOfNight >= 0.75f)
        {
            intensityMultiplier = 0;
        }

        else if (currentTimeOfNight <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfNight - 0.23f) * (1 / 0.02f));
        }

        else if (currentTimeOfNight <= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfNight - 0.75f) * (1 / 0.02f)));
        }

        moon.intensity = moonInitialIntensity * intensityMultiplier;
    }

}
