using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    public int healAmount;
    private float playerLife;

    void Start()
    {
        //float HP = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        //player = GameObject.Find("Player");
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //player.GetComponent<PlayerLife>().Heal(healAmount);
            //playerLife.Heal(healAmount);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
