using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[System.Serializable]
public class Clock : MonoBehaviour
{
    public static Clock SharedInstance;
    public float time = 0;
    public TextMeshProUGUI clockText;
    public Boolean stop = false;
    public int minutesToUnlockMap2 = 15;


    void Awake()
    {
        SharedInstance = this;
    }

    void Update()
    {
        if (!stop)
        {
            time += Time.deltaTime;
            Display();
        }
    }

    public void Display()
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void StopClock()


    {
        string path = JSONSaving.SharedInstance.GetPath();

        if (!System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            PlayerData player = new PlayerData(8, 0, 0, 8, 2, 0, 0, false, false, false, false);
            JSONSaving.SharedInstance.SaveData(player);
        }
        else
        {
            PlayerData check = JSONSaving.SharedInstance.LoadData();
            time = time * (1 + (JSONSaving.SharedInstance.playerData.bonusPoints * 0.25f));
            check.points += (int)time;

            if (time >= (minutesToUnlockMap2 * 60))
            {
                check.map2unlocked = true;
            }

            JSONSaving.SharedInstance.SaveData(check);
            
        }
        stop = true;


    }
}
