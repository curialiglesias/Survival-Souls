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
        if (collision.tag.Contains("Enemy")) {
            Debug.Log(HP);
            Debug.Log("ENTRO");
            enemy.GetComponent<Enemy>().HP = HP - 100;
            Debug.Log(HP);
            Debug.Log(enemy.GetComponent<Enemy>().HP);

        }
    }


}
