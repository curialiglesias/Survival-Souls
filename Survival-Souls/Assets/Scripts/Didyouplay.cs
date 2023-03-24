using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Didyouplay : MonoBehaviour
{
    public GameObject button;
    void Start()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            button.SetActive(false);
        }
    }


    // Update is called once per frame

}
