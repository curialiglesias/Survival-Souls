using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lowLifeSoul : MonoBehaviour
{
    private float playerLife;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        if (playerLife <= 80)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            gameObject.GetComponent<Light2D>().enabled = true;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
        }

    }
}
