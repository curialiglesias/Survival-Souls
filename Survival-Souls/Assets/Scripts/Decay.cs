using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float time;
    void Start()
    {
        InvokeRepeating("Despawn", time, time);
    }
  

    // Update is called once per frame
    public void Despawn()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<RockBehavior>().rb.isKinematic = false;
        gameObject.GetComponent<RockBehavior>().rb.gravityScale = 0f;
        time = 0;
    }
}
