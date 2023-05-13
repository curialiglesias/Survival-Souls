using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class variableLight : MonoBehaviour
{
    private float innerRadius;
    private Boolean auxDecreaseIncrease;


    // Start is called before the first frame update
    void Start()
    {
        innerRadius = gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius;

    }

    // Update is called once per frame
    void Update()
    {


        if (gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius <= 0f)
        {
            auxDecreaseIncrease = true;
        }
        else
        {
            if (gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius >= 0.45f)
            {
                auxDecreaseIncrease = false;

            }
        }

        if (auxDecreaseIncrease)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius = gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius +  0.0025f;
        }
        else
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius = gameObject.GetComponentInChildren<Light2D>().pointLightInnerRadius - 0.0025f;

        }

    }
}
