using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectBossDeath : MonoBehaviour
{
    public GameObject enemy;
    public float HP;
    // Update is called once per frame
    void Update()
    {
        HP = enemy.GetComponent<Enemy>().HP;
        if(HP <= 0)
        {
            this.GetComponent<detectBossDeath>().enabled = false;
        }
    }
}
