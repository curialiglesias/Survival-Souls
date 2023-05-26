using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject creditsPanel;
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
            creditsPanel.SetActive(true);
            }

        }
}
