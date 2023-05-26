using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MapMenu : MonoBehaviour
{
    public GameObject map2Button;
    public TextMeshProUGUI map2Text;
    public TextMeshProUGUI adviceText;

    private bool mapUnlocked;
    private Coroutine activeCoroutine;

    PlayerData PlayerData;

    void OnEnable()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            PlayerData = JSONSaving.SharedInstance.LoadDataFromPath(Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json");
            if (PlayerData != null)
            {
                mapUnlocked = PlayerData.map2unlocked;
            } else
            {
                mapUnlocked = false;
            }
        }
        else
        {
            mapUnlocked = false;
        }
        map2Text.text = "Soul Trials";
        adviceText.color = Color.clear;
    }

    public void map2click()
    {
        if (mapUnlocked)
        {
            StartMap2();
        }
        else
        {
            map2Text.GetComponent<Button>().interactable = false;
            map2Text.GetComponent<Button>().interactable = true;
            map2Text.text = "Locked";
            adviceText.color = Color.white;
            if (activeCoroutine != null)
            {
                StopCoroutine(activeCoroutine);
            }
            activeCoroutine = StartCoroutine(DeactivateMessage(2));
        }
    }

    private IEnumerator DeactivateMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        float timer = 0f;
        float fadeDuration = 2.0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            adviceText.color = Color.Lerp(Color.white, Color.clear, timer / fadeDuration);
            yield return null;
        }
        map2Text.text = "Soul Trials";
    }

    public void StartMap1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartMap2()
    {
        SceneManager.LoadScene("Map2");
    }
}
