using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public float time = 0;
    public TextMeshProUGUI clockText;

    void Update()
    {
        time += Time.deltaTime;
        Display();
    }
    
    public void Display()
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
