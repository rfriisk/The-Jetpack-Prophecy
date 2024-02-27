using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PingLight : MonoBehaviour
{
    private Light2D lightComponent;
    public float startRadius = 0.5f; // Starting radius before each ping
    public float maxRadius = 2.0f; // Maximum expansion radius of the ping
    public float expandSpeed = 1.5f; // Speed at which the light expands
    public float waitTime = 0.8f; // Time to wait before starting the next ping

    private float currentWaitTime; // Tracks the waiting time before starting the next ping

    void Start()
    {
        lightComponent = GetComponent<Light2D>();
        if (lightComponent == null)
        {
            Debug.LogError("ContinuousPingLight script requires a Light2D component on the same GameObject.");
            this.enabled = false;
            return;
        }

        // Initialize the light's radius and the wait timer
        lightComponent.pointLightOuterRadius = startRadius;
        currentWaitTime = waitTime;
    }

    void Update()
    {
        // If the light has reached or exceeded the max radius, reset it and wait before starting the next ping
        if (lightComponent.pointLightOuterRadius >= maxRadius)
        {
            // Reset the light's radius immediately for a sharp ping effect
            // Or you can introduce a fade-out effect here by gradually decreasing the radius and intensity
            lightComponent.pointLightOuterRadius = startRadius;

            // Reset the wait timer
            currentWaitTime = waitTime;
        }
        else if (currentWaitTime > 0)
        {
            // Count down the wait time
            currentWaitTime -= Time.deltaTime;
        }
        else
        {
            // Once the wait time is over, start expanding the light's radius again
            lightComponent.pointLightOuterRadius += Time.deltaTime * expandSpeed;
        }
    }
}
