using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI fuelSpawnedText;
    [SerializeField] private TMPro.TextMeshProUGUI fuelCollectedText;

    public void UpdateTotalFuelSpawned(int total) 
    {
        fuelSpawnedText.text = " / " + total;
    }

    public void UpdateFuelCollected(int collected)
    {
        fuelCollectedText.text = "Fuel: " + collected;
    }

}
