using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour
{
    private int HP = 500;
    private Rigidbody2D rb;

    private float knockbackForce = 20f;
    
    // Start is called before the first frame update

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("Subtract", 1f, 1f);
    }

    void Subtract()
    {
        HP -= 1;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
            HP = HP - 50;
            rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if (HP < 300 && HP > 100)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius = 2;

        }

        if(HP < 100)
        {
            gameObject.GetComponentInChildren<Light2D>().pointLightOuterRadius = 1;
        }

    }

}