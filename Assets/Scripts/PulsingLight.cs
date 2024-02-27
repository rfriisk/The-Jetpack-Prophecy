using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PulsingLight : MonoBehaviour
{
    public Light2D lightComponent;
    public float minRadius = 0.2f;
    public float maxRadius = 1.5f;
    public float pulseSpeed = 1.0f;

    private float targetRadius;
    private float currentRadius;

    void Start()
    {
        if (lightComponent == null)
        {
            Debug.LogError("No Light2D component found. Please assign the Light2D component to the script.");
            this.enabled = false;
            return;
        }
        currentRadius = lightComponent.pointLightOuterRadius;
        targetRadius = maxRadius; // Start by expanding
        Debug.Log("PulsingLight script started. If you see this message but no pulsing occurs, " +
                  "please check the minRadius, maxRadius, and pulseSpeed values in the Inspector.");
    }

    void Update()
    {
        // Log current and target radius for debugging
        Debug.Log("Current Radius: " + currentRadius + " | Target Radius: " + targetRadius);

        // Check if we've reached the target radius within a small threshold and switch direction if so
        if (Mathf.Abs(currentRadius - targetRadius) < 0.01f)
        {
            targetRadius = targetRadius == maxRadius ? minRadius : maxRadius;
            Debug.Log("Switching target radius to: " + targetRadius);
        }

        // Lerp the radius of the light
        currentRadius = Mathf.MoveTowards(currentRadius, targetRadius, Time.deltaTime * pulseSpeed);
        lightComponent.pointLightOuterRadius = currentRadius;
    }
}
