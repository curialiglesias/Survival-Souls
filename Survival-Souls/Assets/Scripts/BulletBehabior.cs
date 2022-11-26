using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabior : MonoBehaviour
{

    private float timer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy")){

            var enemy = collider.gameObject.GetComponent<Enemy>();

            enemy.HP--;

            if (enemy.HP <= 0)
            {
                Destroy(collider.gameObject);
            }
        }

        gameObject.SetActive(false);
    }

    

        private void Update()
    {
        timer += 1.0F * Time.deltaTime;

        if(timer > 5)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
