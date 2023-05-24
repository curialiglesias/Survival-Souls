using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageRoom : MonoBehaviour
{
    public GameObject ScriptHolder;
    private Boolean checkonce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkonce)
        {
            ScriptHolder.GetComponent<TimedRoom>().enabled = true;
            HallManager.SharedInstance.OpenNextDoor();
            checkonce = true;
        }
    }
}
