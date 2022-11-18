using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabior : MonoBehaviour
{

    private void Awake()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
