using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude <= 0.1f)
        {
            yield return new WaitForSeconds(0.5f);
            rb.isKinematic = true;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
    }
}