using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabior : MonoBehaviour
{

    private void Awake()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy")){

            collider.gameObject.GetComponent<Enemy>().HP--;

            if (collider.gameObject.GetComponent<Enemy>().HP <= 0)
            {
                Destroy(collider.gameObject);
            }
        }

        Destroy(gameObject);
    }


}
