using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HallManager : MonoBehaviour
{

    public int RoomLight;
    public static HallManager SharedInstance;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        RoomLight = 0;
    }

   
        public void LightNextRoom()
        {

             gameObject.transform.GetChild(RoomLight).gameObject.SetActive(false);
             RoomLight++;
             gameObject.transform.GetChild(RoomLight).gameObject.SetActive(true);
        }
 

        
    }




