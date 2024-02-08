using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Fuel : MonoBehaviour
{

    [SerializeField]
    private float maxFuel = 100f;
    [SerializeField]
    public float fuelConsumption;
    [SerializeField]
    private float refillFuel;

    private int fuelCanister = 0;

    public float currentFuel;

    public Image[] fuelPoints;

    private FuelManager fuelManager; // Reference to FuelManager.cs

    // JetPack light
    private Light2D jetPackLight;
    private bool isJetPackActive = false;

    private void Start()
    {
        currentFuel = maxFuel;
        jetPackLight = GetComponentInChildren<Light2D>();

        // Initialize FuelManager reference
        fuelManager = FindObjectOfType<FuelManager>();
        if (fuelManager == null)
        {
            Debug.LogError("FuelManager not found in the scene.");
        }
    }

    private void Update()
    {
        if (currentFuel > maxFuel) { currentFuel = maxFuel; }

        FuelBarFiller();

        if (Input.GetButtonUp("Jump"))
        {
            isJetPackActive = false;
            jetPackLight.color = new Color(0.9f, 0.9f, 0.9f, 1f);
            jetPackLight.intensity = 0.53f;
        }

        if (isJetPackActive)
        {
            JetPackLight();
        }

    }

    public void UseJetPack()
    {
        if (currentFuel >= fuelConsumption)
        {
            ConsumeFuel(fuelConsumption);
            isJetPackActive = true;
            Debug.Log("Consumed fuel: " + fuelConsumption);
        }
        else
        {
            Debug.Log("No fuel");
        }
    }

    void ConsumeFuel(float useFuel)
    {
        if (currentFuel > 0) { currentFuel -= useFuel; }

        Debug.Log("Current fuel:" + currentFuel);

    }

    void FuelBarFiller()
    {
        for (int i = 0; i < fuelPoints.Length; i++)
        {
            fuelPoints[i].enabled = !DisplayFuelPoints(currentFuel, i);

            //Debug.Log("Fuel Point " + i + " enabled: " + fuelPoints[i].enabled);
        }
    }

    bool DisplayFuelPoints(float _fuel, int pointNumb)
    {
        return ((pointNumb * 10) >= _fuel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FuelCanister"))
        {
            Destroy(collision.gameObject);
            fuelCanister++;

            // Add refillFuel to currentFuel
            currentFuel += refillFuel;

            // Ensuring currentFuel doesn�t exceed maxFuel
            if (currentFuel > maxFuel)
            {
                currentFuel = maxFuel;
            }

            FuelBarFiller();

            if (fuelManager != null)
            {
                fuelManager.UpdateFuelCollected(fuelCanister);
            }
            else
            {
                Debug.LogError("FuelManager is null");
            }

            Debug.Log("FuelCanister: " + fuelCanister);
        }
    }

    private void JetPackLight()
    {

        if (jetPackLight != null && isJetPackActive && currentFuel > 0)
        {
            // Randomize the intensity of the light between a min and max range
            float intensity = UnityEngine.Random.Range(0.5f, 1.5f);
            jetPackLight.intensity = intensity;

            // Optionally, change the color slightly to simulate fire
            float r = UnityEngine.Random.Range(0.8f, 1f); // Red
            float g = UnityEngine.Random.Range(0.4f, 0.6f); // Green
            float b = UnityEngine.Random.Range(0.1f, 0.3f); // Blue

            jetPackLight.color = new Color(r, g, b);
            jetPackLight.enabled = true;
        }
        else if (jetPackLight != null)
        {
            jetPackLight.enabled = false;
        }

    }

}


