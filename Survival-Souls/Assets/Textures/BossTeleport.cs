using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{

    public TextMeshProUGUI pressE;
    private Vector2 initialPosition = new Vector2(-31.69f, -1.16f);
    public GameObject ScriptHolder1;
    public GameObject ScriptHolder2;
    public GameObject audio;


    private void OnTriggerStay2D(Collider2D collision)
    {
        pressE.text = "E";
        if (Input.GetKeyDown(KeyCode.E))
        {
            audio.GetComponent<AudioSource>().Play();

            ScriptHolder1.GetComponent<GreyollLegacy>().enabled = true;
            ScriptHolder2.GetComponent<spawnGolemsMap2>().enabled = true;
            collision.attachedRigidbody.transform.position = initialPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.text = "";
    }

}
