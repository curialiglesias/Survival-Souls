using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingController : MonoBehaviour
{
    private bool canFreeze = false;
    public GameObject IceCollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("IceCollider") && !canFreeze)
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
