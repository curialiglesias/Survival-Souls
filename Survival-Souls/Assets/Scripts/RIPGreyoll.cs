using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RIPGreyoll : MonoBehaviour
{

    public GameObject enemy;
    public GameObject slider;
    private float HP;

    private void OnTriggerExit2D(Collider2D collision)
    {
        HP = enemy.GetComponent<Enemy>().HP;
        if (collision.tag.Contains("Golem")) {
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
