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
    public GameObject audio;

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.text = "";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pressE.text = "E";

            if (Input.GetKeyDown(KeyCode.E))
            {
                audio.GetComponent<AudioSource>().Play();
                collision.gameObject.GetComponent<PlayerLife>().HP = 200;

                if (!isTutorial)
                {
                    HallManager.SharedInstance.LightNextRoom();
                    HallManager.SharedInstance.OpenNextDoor();
                }

                collision.attachedRigidbody.transform.position = initialPosition;
            }
        }
        
    }


}
