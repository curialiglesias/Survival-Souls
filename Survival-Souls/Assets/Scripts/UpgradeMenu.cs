using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UpgradeMenu : MonoBehaviour
{
    PlayerData PlayerData;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;
    public float moneyValue;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;
    public TextMeshProUGUI text9;
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
    public TextMeshProUGUI cost7;
    public TextMeshProUGUI cost8;
    public TextMeshProUGUI cost9;

    private int dashCost = 1000;
    private int doubleShotCost = 2000;
    private int chargedShotCost = 5000;

    void Start()
    {
        //Upgrades
        PlayerData = JSONSaving.SharedInstance.LoadDataFromPath(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json");
        moneyValue = PlayerData.points;
        text1.text = "Speed: " + (1 + PlayerData.velocity * 0.125) + "X";
        text2.text = "Damage: " + (1 + PlayerData.damage * 0.25) + "X";
        text3.text = "Defense: " + (1 + PlayerData.defense * 0.25) + "X";
        text4.text = "SoulTime: " + (200 + PlayerData.soulTime * 25) + "s";
        text5.text = "SoulDecay: " + (1 + PlayerData.decraseRate * 0.25) + "X";
        text6.text = "SoulValue: " + (1 + PlayerData.bonusPoints * 0.25) + "X";
        cost1.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.velocity, 2));
        cost2.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.damage, 2));
        cost3.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.defense, 2));
        cost4.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.soulTime, 2));
        cost5.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.decraseRate, 2));
        cost6.text = "Cost: " + (50 + 50 * Mathf.Pow(PlayerData.bonusPoints, 2));
        upgrade1.text = "lvl: " + (1 + PlayerData.velocity);
        upgrade2.text = "lvl: " + (1 + PlayerData.damage); 
        upgrade3.text = "lvl: " + (1 + PlayerData.defense); 
        upgrade4.text = "lvl: " + (1 + PlayerData.soulTime);
        upgrade5.text = "lvl: " + (1 + PlayerData.decraseRate);
        upgrade6.text = "lvl: " + (1 + PlayerData.bonusPoints);

        //Skills
        text7.text = PlayerData.dash ? "Dash: Activated" : "Dash: Not Purchased";
        text8.text = PlayerData.doubleShot ? "Double Shot: Activated" : "Double Shot: Not Purchased";
        text9.text = PlayerData.chargedShot ? "Charged Shot: Activated" : "Charged Shot: Not Purchased";
        cost7.text = PlayerData.dash ? "" : "Cost: " + dashCost;
        cost8.text = PlayerData.doubleShot ? "" : "Cost: " + doubleShotCost;
        cost9.text = PlayerData.chargedShot ? "" : "Cost: " + chargedShotCost;

        UpdateSoul();
    }

    public void UpdateSoul()
    {
        moneyText.text = "SoulPoints: " + moneyValue.ToString();
        moneyText2.text = "SoulPoints: " + moneyValue.ToString();

    }
    public void UpdateStats()
    {
        float.TryParse(Regex.Match(upgrade1.text, @"\d+").Value, out float value1);
        text1.text = "Speed: " + (1 + (value1 - 1) * 0.125) + "X";
        cost1.text = "Cost: " + (50 + 50 * Mathf.Pow(value1 - 1,2));

        float.TryParse(Regex.Match(upgrade2.text, @"\d+").Value, out float value2);
        text2.text = "Damage: " + (1 + (value2 - 1) * 0.25) + "X";
        cost2.text = "Cost: " + (50 + 50 * Mathf.Pow(value2 - 1, 2));

        float.TryParse(Regex.Match(upgrade3.text, @"\d+").Value, out float value3);
        text3.text = "Defense: " + (1 + (value3 - 1) * 0.25) + "X";
        cost3.text = "Cost: " + (50 + 50 * Mathf.Pow(value3 - 1, 2));

        float.TryParse(Regex.Match(upgrade4.text, @"\d+").Value, out float value4);
        text4.text = "SoulTime: " + (200 + (value4 - 1) * 25) + "s";
        cost4.text = "Cost: " + (50 + 50 * Mathf.Pow(value4 - 1, 2));

        float.TryParse(Regex.Match(upgrade5.text, @"\d+").Value, out float value5);
        text5.text = "SoulDecay: " + (1 + (value5 - 1) * 0.25) + "X";
        cost5.text = "Cost: " + (50 + 50 * Mathf.Pow(value5 - 1, 2));

        float.TryParse(Regex.Match(upgrade6.text, @"\d+").Value, out float value6);
        text6.text = "SoulValue: " + (1 + (value6 - 1) * 0.25) + "X";
        cost6.text = "Cost: " + (50 + 50 * Mathf.Pow(value6 - 1, 2));
    }


    public void purchase(TextMeshProUGUI upgrade)
    {
        int.TryParse(Regex.Match(upgrade.text, @"\d+").Value, out int value);
        if(moneyValue >= (50 + 50 * Mathf.Pow(value - 1, 2)) && value < 5)
        {
            if(value == 5)
            {
                upgrade.text = "lvl MAX";
            }
            else
            {

                moneyValue = moneyValue - (50 + 50 * Mathf.Pow(value - 1, 2));
                value++;
                upgrade.text = "lvl " + value.ToString();

                UpdateSoul();
            }
        }
        
        UpdateStats();
    }

    public void purchaseSkill(TextMeshProUGUI skill)
    {
        switch (skill.text)
        {
            case "Dash: Not Purchased":
                if (moneyValue >= dashCost)
                {
                    moneyValue -= dashCost;
                    text7.text = "Dash: Activated";
                    cost7.text = "";
                    PlayerData.dash = true;
                }
                break;

            case "Double Shot: Not Purchased":
                if (moneyValue >= doubleShotCost)
                {
                    moneyValue -= doubleShotCost;
                    text8.text = "Double Shot: Activated";
                    cost8.text = "";
                    PlayerData.doubleShot = true;
                }
                break;

            case "Charged Shot: Not Purchased":
                if (moneyValue >= chargedShotCost)
                {
                    moneyValue -= chargedShotCost;
                    text9.text = "Charged Shot: Activated";
                    cost9.text = "";
                    PlayerData.dash = true;
                }
                break;

            default:
                break;
        }

        UpdateSoul();
    }

    public void Save()
    {
        //parses the first number on a string
        float.TryParse(Regex.Match(upgrade1.text, @"\d+").Value , out float value1);
        float.TryParse(Regex.Match(upgrade2.text, @"\d+").Value, out float value2);
        float.TryParse(Regex.Match(upgrade3.text, @"\d+").Value, out float value3);
        float.TryParse(Regex.Match(upgrade4.text, @"\d+").Value, out float value4);
        float.TryParse(Regex.Match(upgrade5.text, @"\d+").Value, out float value5);
        float.TryParse(Regex.Match(upgrade6.text, @"\d+").Value, out float value6);
        /*int.TryParse(upgrade2.text, out int value2);
        int.TryParse(upgrade3.text, out int value3);
        int.TryParse(upgrade4.text, out int value4);
        int.TryParse(upgrade5.text, out int value5);
        int.TryParse(upgrade6.text, out int value6);*/
        PlayerData.points = moneyValue;
        PlayerData.velocity = value1 - 1;
        PlayerData.damage = value2 - 1;
        PlayerData.defense = value3 - 1;
        PlayerData.soulTime = value4 - 1;
        PlayerData.decraseRate = value5 - 1;
        PlayerData.bonusPoints = value6 - 1;

        JSONSaving.SharedInstance.SaveData(PlayerData);
    }
}
