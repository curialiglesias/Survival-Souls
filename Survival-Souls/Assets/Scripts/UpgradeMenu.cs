using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UpgradeMenu : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int moneyValue;
    PlayerData PlayerData;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI upgrade1;
    public TextMeshProUGUI upgrade2;
    public TextMeshProUGUI upgrade3;
    public TextMeshProUGUI upgrade4;
    public TextMeshProUGUI upgrade5;
    public TextMeshProUGUI upgrade6;
    public TextMeshProUGUI cost1;
    public TextMeshProUGUI cost2;
    public TextMeshProUGUI cost3;
    public TextMeshProUGUI cost4;
    public TextMeshProUGUI cost5;
    public TextMeshProUGUI cost6;

    void Start()
    {
        PlayerData = JSONSaving.SharedInstance.LoadDataFromPath(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json");
        moneyValue = PlayerData.points;
        text1.text = "Speed: " + (1 + PlayerData.velocity * 0.25) + "X";
        text2.text = "Damage: " + (1 + PlayerData.damage * 0.25) + "X";
        text3.text = "Defense: " + (1 + PlayerData.defense * 0.25) + "X";
        text4.text = "SoulTime: " + (200 + PlayerData.soulTime * 25) + "s";
        text5.text = "SoulDecay: " + (1 + PlayerData.decraseRate * 0.25) + "X";
        text6.text = "SoulValue: " + (1 + PlayerData.bonusPoints * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * PlayerData.velocity ^ 2);
        cost2.text = "Cost: " + (50 + 50 * PlayerData.damage ^ 2);
        cost3.text = "Cost: " + (50 + 50 * PlayerData.defense ^ 2);
        cost4.text = "Cost: " + (50 + 50 * PlayerData.soulTime ^ 2);
        cost5.text = "Cost: " + (50 + 50 * PlayerData.decraseRate ^ 2);
        cost6.text = "Cost: " + (50 + 50 * PlayerData.bonusPoints ^ 2);
        upgrade1.text = "lvl: " + (1 + PlayerData.velocity);
        upgrade2.text = "lvl: " + (1 + PlayerData.damage); 
        upgrade3.text = "lvl: " + (1 + PlayerData.defense); 
        upgrade4.text = "lvl: " + (1 * PlayerData.soulTime);
        upgrade5.text = "lvl: " + (1 * PlayerData.decraseRate);
        upgrade6.text = "lvl: " + (1 * PlayerData.bonusPoints);

        UpdateSoul();
    }

    public void UpdateSoul()
    {
        moneyText.text = "SoulPoints: " + moneyValue.ToString();
        
    }
    public void UpdateStats()
    {
        int.TryParse(Regex.Match(upgrade1.text, @"\d+").Value, out int value1);
        text1.text = "Speed: " + (1 + value1 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value1 ^ 2);

        int.TryParse(Regex.Match(upgrade2.text, @"\d+").Value, out int value2);
        text1.text = "Speed: " + (1 + value2 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value2 ^ 2);

        int.TryParse(Regex.Match(upgrade3.text, @"\d+").Value, out int value3);
        text1.text = "Speed: " + (1 + value3 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value3 ^ 2);

        int.TryParse(Regex.Match(upgrade4.text, @"\d+").Value, out int value4);
        text1.text = "Speed: " + (1 + value4 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value4 ^ 2);

        int.TryParse(Regex.Match(upgrade5.text, @"\d+").Value, out int value5);
        text1.text = "Speed: " + (1 + value5 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value5 ^ 2);

        int.TryParse(Regex.Match(upgrade6.text, @"\d+").Value, out int value6);
        text1.text = "Speed: " + (1 + value6 * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * value6 ^ 2);
    }


    public void purchase(TextMeshProUGUI upgrade)
    {

        int.TryParse(upgrade.text, out int value);
        if(moneyValue >= (50 * value^2) && value < 5)
        {
            value++;
            if(value == 5)
            {
                upgrade.text = "lvl MAX";
            }
            else
            {
                upgrade.text = "lvl " + value.ToString();

                moneyValue = moneyValue - 50 + 50 * (value - 1) ^ 2;
                UpdateSoul();
                UpdateStats();
            }
        }
    }

    public void Save()
    {
        //parses the first number on a string
        int.TryParse(Regex.Match(upgrade1.text, @"\d+").Value , out int value1);
        int.TryParse(Regex.Match(upgrade2.text, @"\d+").Value, out int value2);
        int.TryParse(Regex.Match(upgrade3.text, @"\d+").Value, out int value3);
        int.TryParse(Regex.Match(upgrade4.text, @"\d+").Value, out int value4);
        int.TryParse(Regex.Match(upgrade5.text, @"\d+").Value, out int value5);
        int.TryParse(Regex.Match(upgrade6.text, @"\d+").Value, out int value6);
        /*int.TryParse(upgrade2.text, out int value2);
        int.TryParse(upgrade3.text, out int value3);
        int.TryParse(upgrade4.text, out int value4);
        int.TryParse(upgrade5.text, out int value5);
        int.TryParse(upgrade6.text, out int value6);*/
        PlayerData.points = moneyValue;
        PlayerData.velocity = value1;
        PlayerData.damage = value2;
        PlayerData.defense = value3;
        PlayerData.soulTime = value4;
        PlayerData.decraseRate = value5;
        PlayerData.bonusPoints = value6;

        JSONSaving.SharedInstance.SaveData(PlayerData);
    }
}
