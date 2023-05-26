using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CreditsTeleport : MonoBehaviour
{
    public TextMeshProUGUI pressE;
    private Vector2 initialPosition = new Vector2(29.05f, 22.98f);
    public GameObject audio;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressE.text = "E";
            audio.GetComponent<AudioSource>().Play();

            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.attachedRigidbody.transform.position = initialPosition;
            }
        }
       
    }
}
