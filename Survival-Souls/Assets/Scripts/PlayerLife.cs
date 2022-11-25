using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour
{
    private int HP = 500;
    
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
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

}