using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;

public class CreditsTeleport : MonoBehaviour
{
    public TextMeshProUGUI pressE;
    private Vector2 initialPosition = new Vector2(29.05f, 22.98f);

    private void OnTriggerStay2D(Collider2D collision)
    {
        pressE.text = "E";

        if (Input.GetKeyDown(KeyCode.E))
        {
            collision.attachedRigidbody.transform.position = initialPosition;
        }
    }
}
