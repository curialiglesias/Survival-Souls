using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingController : MonoBehaviour
{
    private bool canFreeze = false;
    public GameObject enemy;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<ParticleSystem>() != null && !canFreeze)
    //    {
            
    //    }
    //}

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject == enemy && !canFreeze)
        {
            Debug.Log("Start freeze");
            canFreeze = true;
            Invoke("StopFreeze", 1f);
        }
    }

    private void StopFreeze()
    {
        Debug.Log("Stop freeze");
        canFreeze = false;
    }
}
