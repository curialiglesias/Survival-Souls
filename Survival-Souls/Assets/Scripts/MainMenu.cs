using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartMap1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartMap2()
    {
        SceneManager.LoadScene("Map2");
    }

    public void QuitApplication()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
