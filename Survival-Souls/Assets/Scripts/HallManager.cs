using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HallManager : MonoBehaviour
{

    private int RoomLight;
    private int Door;
    public static HallManager SharedInstance;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        RoomLight = 0;
        Door = 5;
    }

   
        public void LightNextRoom()
        {

             gameObject.transform.GetChild(RoomLight).gameObject.SetActive(false);
             RoomLight++;
             gameObject.transform.GetChild(RoomLight).gameObject.SetActive(true);
        }
        
        public void OpenNextDoor()
    {
        if(Door == 5)
        {
            gameObject.SetActive(true);
        }
        gameObject.transform.GetChild(Door).gameObject.GetComponent<OpenDoors>().DoorAction();
        Door++;
        gameObject.transform.GetChild(Door).gameObject.GetComponent<OpenDoors>().DoorAction();
    }
 

        
    }




