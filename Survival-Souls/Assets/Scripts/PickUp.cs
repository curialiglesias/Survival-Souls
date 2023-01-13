using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    public int healAmount;
    //public AudioSource pickUpSound;

    void Start()
    {
        //float HP = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        //playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerLife>().Heal(healAmount);
            //pickUpSound.Play();
            gameObject.SetActive(false);
        }
    }
}
