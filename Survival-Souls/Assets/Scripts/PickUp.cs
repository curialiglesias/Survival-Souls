using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    public int healAmount;

    void Start()
    {
        //float HP = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        //playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerLife>().Heal(healAmount);
            gameObject.SetActive(false);
        }
    }
}
