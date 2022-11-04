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
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void Start()
    {
        InvokeRepeating("Subtract", 1f, 1f);
        if(HP < 200)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius --;

        }
    }

    void Subtract()
    {
        HP -= 100;
    }


}