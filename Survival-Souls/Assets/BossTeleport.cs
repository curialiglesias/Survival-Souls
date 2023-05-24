using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{

    public TextMeshProUGUI pressE;
    private Vector2 initialPosition = new Vector2(-31.69f, -1.16f);
    public GameObject ScriptHolder1;
    public GameObject ScriptHolder2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        pressE.text = "E";

        if (Input.GetKeyDown(KeyCode.E))
        {

            ScriptHolder1.GetComponent<GreyollLegacy>().enabled = true;
            ScriptHolder2.GetComponent<spawnGolemsMap2>().enabled = true;
            collision.attachedRigidbody.transform.position = initialPosition;
        }
    }

}
