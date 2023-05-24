using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextRoom : MonoBehaviour
{
    public GameObject door1;
    public int condition;
    private Boolean stop = false;

    // Update is called once per frame
    void Update()
    {


        if ( GetComponentsInChildren<Transform>().GetLength(0) == condition && !stop)
        {
            stop = true;
            door1.SetActive(false);
        }
    }
}
