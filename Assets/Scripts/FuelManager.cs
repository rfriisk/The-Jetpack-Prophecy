using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI fuelSpawnedText;
    [SerializeField] private TMPro.TextMeshProUGUI fuelCollectedText;

    private void Start()
    {
        UpdateFuelCollected(0);
    }

    public void UpdateTotalFuelSpawned(int total)
    {
        fuelSpawnedText.text = " / " + total;
    }

    public void UpdateFuelCollected(int collected)
    {
        fuelCollectedText.text = "Fuel: " + collected;
    }

}
