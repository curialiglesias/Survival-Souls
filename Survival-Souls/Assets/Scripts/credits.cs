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
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            GameObject.Find("Cursor").SetActive(false);
            collision.GetComponent<PlayerController>().enabled = false;
            collision.GetComponent<WeaponAim>().enabled = false;
            collision.GetComponent<ShootBow>().enabled = false;
            collision.GetComponent<AudioSource>().Pause();
            Cursor.visible = true;
            creditsPanel.SetActive(true);
        }

    }
}
