using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public float time = 0;
    // Update is called once per frame
    void Update()
    {
         time += Time.deltaTime;
    }
}
