using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public TextMeshProUGUI moneyValue;
    PlayerData PlayerData;

    void Start()
    {
        PlayerData = JSONSaving.SharedInstance.LoadDataFromPath("C:\\Users\\jllob\\AppData\\LocalLow\\StreetLight-Productions\\Survival-Souls\\SaveData.json");
    }

    public void Display()
    {
        moneyValue.text = "Points: " + PlayerData.points.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Display();
    }
}
