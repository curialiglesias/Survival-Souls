using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRoom : MonoBehaviour
{
    public int RoomLight = 0;


    void Start()
    {
        InvokeRepeating("TickLight", 10, 60);
    }

    // Update is called once per frame


    private void TickLight()
    {
        gameObject.transform.GetChild(RoomLight).gameObject.SetActive(false);
        RoomLight++;
        if(RoomLight == 5)
        {
            CancelInvoke();
        }
    }


}
