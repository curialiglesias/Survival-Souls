using System;
using System.Collections;
using System.Collections.Generic;
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
    Boolean stop = false;


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

        if (!System.IO.File.Exists(path))
        {
            PlayerData player = new PlayerData((int)time, 1, 1, 1, 1, 1);
            JSONSaving.SharedInstance.SaveData(player);
        }
        else
        {
            PlayerData check = JSONSaving.SharedInstance.LoadData();
            check.points += (int)time;
            JSONSaving.SharedInstance.SaveData(check);
            stop = true;
        }
        

    }
}
