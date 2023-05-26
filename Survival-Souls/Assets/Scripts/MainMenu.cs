using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainMenu : MonoBehaviour
{
    public GameObject mapMenu;
    public GameObject upgradesMenu;
    public GameObject upgradesButton;

    void Start()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            upgradesButton.SetActive(false);
        }
    }

    public void StartGame()
    {
        // Nonsense fix for a problem I don't understand about JSONSaving
        if (System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            upgradesMenu.SetActive(true);
            upgradesMenu.SetActive(false);
        }
        mapMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitApplication()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
 
}
