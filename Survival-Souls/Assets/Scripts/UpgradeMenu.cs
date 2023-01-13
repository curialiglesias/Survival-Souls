using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UpgradeMenu : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int moneyValue;
    PlayerData PlayerData;
    public TextMeshProUGUI upgrade1;
    public TextMeshProUGUI upgrade2;
    public TextMeshProUGUI upgrade3;
    public TextMeshProUGUI upgrade4;
    public TextMeshProUGUI upgrade5;
    void Start()
    {
        PlayerData = JSONSaving.SharedInstance.LoadDataFromPath(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json");
        moneyValue = PlayerData.points;
        upgrade1.text = PlayerData.velocity.ToString();
        upgrade2.text = PlayerData.attack.ToString();
        upgrade3.text = PlayerData.soulTime.ToString();
        upgrade4.text = PlayerData.decraseRate.ToString();
        upgrade5.text = PlayerData.bonusPoints.ToString();
    }

    public void Display()
    {
        moneyText.text = "Points: " + moneyValue.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        Display();
    }
    public void purchase(TextMeshProUGUI upgrade)
    {
        int value;
        int.TryParse(upgrade.text, out value);
        if(moneyValue >= 50)
        {
            value++;
            upgrade.text = value.ToString();
            moneyValue = moneyValue - 50;
        }
    }
    public void Save()
    {

        int value1;
        int value2;
        int value3;
        int value4;
        int value5;
        int.TryParse(upgrade1.text, out value1);
        int.TryParse(upgrade2.text, out value2);
        int.TryParse(upgrade3.text, out value3);
        int.TryParse(upgrade4.text, out value4);
        int.TryParse(upgrade5.text, out value5);
        PlayerData.points = moneyValue;
        PlayerData.velocity = value1;
        PlayerData.attack = value2;
        PlayerData.soulTime = value3;
        PlayerData.decraseRate = value4;
        PlayerData.bonusPoints = value5;

        JSONSaving.SharedInstance.SaveData(PlayerData);
    }
}
