using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    public float healAmount;

    void Start()
    {
        healAmount = healAmount  * (1 + JSONSaving.SharedInstance.playerData.bonusPoints * 0.25f);
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerLife>().Heal(healAmount);
            GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
