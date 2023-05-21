using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeleportCircle : MonoBehaviour
{
    public Boolean isTutorial;
    public TextMeshProUGUI pressE;
    private Vector2 initialPosition = new Vector2(0.097f, 7.75f);

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.text = "";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pressE.text = "E";

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isTutorial)
            {
                HallManager.SharedInstance.LightNextRoom();
            }
            collision.attachedRigidbody.transform.position = initialPosition;
        }
    }


}
