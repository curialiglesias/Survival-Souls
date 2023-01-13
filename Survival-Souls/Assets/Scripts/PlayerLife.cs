using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour
{
    public float HP = 500;
    public float HPDecraseRate = 5;
    public GameObject gameOverPanel;

    private float maxHP;
    private float radius;
    private float maxRadius;
    private float minRadius;

    private Boolean stop = false;

    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
        maxHP = HP;
        maxRadius = gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius;
        minRadius = 0.25f;
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
        Clock.SharedInstance.StopClock();
    }

    public void Heal(int amount)
    {
        if (HP >= 0)
        {
            HP += amount;
            if (HP > maxHP) { HP = maxHP; }
        }
    }
}