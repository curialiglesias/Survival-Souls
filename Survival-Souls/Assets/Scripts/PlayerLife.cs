using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour
{
    public float HP = 200;
    private float HPDecraseRate = 3;
    public GameObject gameOverPanel;

    private float maxHP;
    private float radius;
    private float maxRadius;
    private float minRadius;

    private Boolean stop = false;

    // Start is called before the first frame update
    void Start()
    {

        HPDecraseRate = HPDecraseRate / (1 + JSONSaving.SharedInstance.playerData.decraseRate * 0.25f);
        HP = HP + (JSONSaving.SharedInstance.playerData.soulTime * 25);
        InvokeRepeating("Subtract", 1f, 1f);
        maxHP = HP;
        maxRadius = gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius;
        minRadius = 0.90f;

    }



    void Subtract()
    {
        HP -= HPDecraseRate;
    }

    void Update()
    {
        if (!stop)
        {
            radius = (HP / maxHP) * maxRadius;
            if (radius > minRadius)
            {
                GetComponentInChildren<Light2D>().pointLightOuterRadius = radius;
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