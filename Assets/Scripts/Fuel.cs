using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        currentFuel = maxFuel;
    }

    private void Update()
    {
        if (currentFuel > maxFuel) { currentFuel = maxFuel; }

        FuelBarFiller();
    }

    public void UseJetPack()
    {
        if (currentFuel >= fuelConsumption)
        {
            ConsumeFuel(fuelConsumption);
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
        //Debug.Log("Fuel used:" + fuelConsumption + " useFuel: " + useFuel);

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

            // Ensuring currentFuel doesn´t exceed maxFuel
            if (currentFuel > maxFuel)
            {
                currentFuel = maxFuel;
            }

            FuelBarFiller();

            Debug.Log("FuelCanister: " + fuelCanister);
        }
    }


    //private int fuelCanister = 0;

    //[SerializeField]
    //public float currentFuel, maxFuel = 100f;
    //[SerializeField]
    //public float fuelConsumption = 10f;
    //[SerializeField]
    //public float refillFuel;

    //public Image[] fuelPoints;

    //void Start()
    //{
    //    currentFuel = maxFuel;
    //}

    //void Update()
    //{
    //    if (currentFuel > maxFuel) { currentFuel = maxFuel; }

    //    FuelBarFiller();
    //}

    //public void UseJetPack(float amount)
    //{
    //    ConsumeFuel(amount);
    //    Debug.Log("Consumed Fuel amount: " + amount);
    //}

    //void ConsumeFuel(float useFuel)
    //{
    //    if (currentFuel < maxFuel) { currentFuel -= useFuel; }
    //    //currentFuel = (int)Mathf.Clamp(currentFuel - fuelConsumption, 0f, maxFuel);
    //    Debug.Log("Current fuel:" + currentFuel);
    //    Debug.Log("Fuel used:" + fuelConsumption + " useFuel: " + useFuel);

    //    //UpdateFuelPointsDisplay();

    //}


    //void Refuel(float getFuel)
    //{
    //    if (currentFuel < maxFuel) { currentFuel += getFuel; }

    //    currentFuel = Mathf.Clamp(currentFuel + refillFuel, 0f, maxFuel);

    //    Debug.Log("(Refuel) Current fuel: " + currentFuel);

    //    UpdateFuelPointsDisplay();
    //}
    //void FuelBarFiller()
    //{
    //    for (int i = 0; i < fuelPoints.Length; i++)
    //    {
    //        fuelPoints[i].enabled = !DisplayFuelPoints(currentFuel, i);
    //    }
    //}

    //bool DisplayFuelPoints(float _fuel, int pointNumb)
    //{
    //    return ((pointNumb * 10) >= _fuel);
    //}

    //void UpdateFuelPointsDisplay()
    //{
    //    float fuelRatio = currentFuel / maxFuel;
    //    int pointsToDisplay = Mathf.CeilToInt(fuelPoints.Length * fuelRatio);

    //    for(int i = 0; i < fuelPoints.Length; i++)
    //    {
    //        fuelPoints[i].enabled = i > pointsToDisplay;
    //    }

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("FuelCanister"))
    //    {
    //        Destroy(collision.gameObject);
    //        fuelCanister++;

    //        //Refuel();

    //        Debug.Log("FuelCanister: " +  fuelCanister);
    //    }
    //}
}
