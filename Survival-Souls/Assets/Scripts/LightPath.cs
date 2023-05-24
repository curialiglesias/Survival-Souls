using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPath : MonoBehaviour
{
    private Light2D light;
    private SpriteRenderer spriterenderer;
    private void Start()
    {
        light = GetComponent<Light2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if( GetComponentsInChildren<Transform>().GetLength(0) == 1)
        {
            LightPathOn();
            Debug.Log("is lit");
            this.enabled = false;
        }
    }

    private void LightPathOn()
    {
        light.enabled = true;
        spriterenderer.enabled = true;
    }





}

