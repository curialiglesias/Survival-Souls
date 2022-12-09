using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour
{
    public int HP = 500;
    private Rigidbody2D rb;

    private float knockbackForce = 20;
    private int maxHP;
    
    // Start is called before the first frame update

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("Subtract", 1f, 1f);
        maxHP = HP;
    }

    void Subtract()
    {
        HP -= 1;
    }

    void Update()
    {
        if (HP < 300 && HP > 100)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius = 2;

        }

        if(HP < 100)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius = 1;
        }

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