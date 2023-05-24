using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public float HP = 200;
    private float HPDecraseRate = 3;
    public GameObject gameOverPanel;

    private float maxHP;
    private float outerRadius;
    private float innerRadius;
    private float maxOuterRadius;
    private float maxInnerRadius;
    private float minRadius;

    private Boolean stop = false;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "Map2")
        {
            HPDecraseRate = 0;
        }
        else{
            HPDecraseRate = HPDecraseRate / (1 + JSONSaving.SharedInstance.playerData.decraseRate * 0.25f);
        }

        HP = HP + (JSONSaving.SharedInstance.playerData.soulTime * 75);
        InvokeRepeating("Subtract", 1f, 1f);
        maxHP = HP;
        maxOuterRadius = gameObject.GetComponent<Light2D>().pointLightOuterRadius;
        maxInnerRadius = gameObject.GetComponent<Light2D>().pointLightInnerRadius;
        minRadius = 0.5f;

    }

    void Subtract()
    {
        HP -= HPDecraseRate;
    }

    void Update()
    {
        if (!stop)
        {
            outerRadius = Mathf.Lerp(maxOuterRadius, minRadius, 1 - (HP / maxHP));
            innerRadius = Mathf.Lerp(maxInnerRadius, 0, 1 - (HP / maxHP));

            if (outerRadius > minRadius)
            {
                GetComponent<Light2D>().pointLightOuterRadius = outerRadius;
                GetComponent<Light2D>().pointLightInnerRadius = innerRadius;
            }

            if (HP <= 0)
            {
                GameOver();
                stop = true;
            }
        }

    }

    public void GameOver()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        gameOverPanel.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<WeaponAim>().enabled = false;
        GetComponent<ShootBow>().enabled = false;
        GameObject.Find("Cursor").SetActive(false);
        Cursor.visible = true;
        Clock.SharedInstance.StopClock();
    }

    public void Heal(float amount)
    {
        if (HP >= 0)
        {
            HP += amount;
            if (HP > maxHP) { HP = maxHP; }
        }
    }
}