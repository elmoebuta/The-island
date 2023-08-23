using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 86400.0f;  // Total duration of a day in seconds.
    public float minIntensity = 0.0f;  // Minimum light intensity.
    public float maxIntensity = 1.0f;  // Maximum light intensity.

    private Light directionalLight;
    private float startTime;

    private void Start()
    {
        directionalLight = GetComponent<Light>();
        startTime = Time.time;
    }

    private void Update()
    {
        // Calculate the current time of day as a value between 0 and 1.
        float currentTimeOfDay = (Time.time - startTime) / dayDuration;

        // Ensure the value is between 0 and 1.
        currentTimeOfDay = Mathf.Clamp01(currentTimeOfDay);

        // Calculate the new intensity based on the time of day.
        float newIntensity = Mathf.Lerp( maxIntensity, minIntensity, currentTimeOfDay);

        // Set the light intensity.
        directionalLight.intensity = newIntensity;
    }
}
