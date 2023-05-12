using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowLifeSoul : MonoBehaviour
{
    private float playerLife;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = GameObject.Find("Player").GetComponent<PlayerLife>().HP;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife <= 80)
        {
            gameObject.SetActive(true);
        }
    }
}
