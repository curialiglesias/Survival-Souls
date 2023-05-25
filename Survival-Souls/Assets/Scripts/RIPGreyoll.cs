using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIPGreyoll : MonoBehaviour
{

    public GameObject enemy;
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
        }
    }


}
