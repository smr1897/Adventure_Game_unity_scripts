using UnityEngine;

public class DayNightCycleManager : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public Light sun;

    void Start()
    {
        // Set the initial skybox and lighting
        SetDay();
    }

    void Update()
    {
        // Example: You can use a timer or other conditions to trigger day and night transitions
        // For simplicity, let's use a key press for demonstration purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleDayNight();
        }
    }

    void ToggleDayNight()
    {
        if (RenderSettings.skybox == daySkybox)
        {
            SetNight();
        }
        else
        {
            SetDay();
        }
    }

    void SetDay()
    {
        RenderSettings.skybox = daySkybox;
        sun.intensity = 1f;  // Adjust light intensity for day
    }

    void SetNight()
    {
        RenderSettings.skybox = nightSkybox;
        sun.intensity = 0.2f;  // Adjust light intensity for night
    }
}
