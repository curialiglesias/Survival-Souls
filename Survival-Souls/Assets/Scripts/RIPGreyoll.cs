using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RIPGreyoll : MonoBehaviour
{

    public GameObject enemy;
    public GameObject slider;
    private float HP;
    public GameObject player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("Golem") && !player.GetComponent<PlayerController>().isDashing) {
            enemy.GetComponent<Enemy>().HP = HP - 100;
        }

    }

    private void Update()
    {
        HP = enemy.GetComponent<Enemy>().HP;

        if(HP <= 0)
        {
            enemy.SetActive(false);
            slider.SetActive(false);
        }
    }


}
