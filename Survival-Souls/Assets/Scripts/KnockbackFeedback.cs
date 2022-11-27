using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackFeedback : MonoBehaviour
{

    [SerializeField]
    private float strength = 16, delay = 0.15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                Vector2 difference = ((rb2d.transform.position - transform.position).normalized) * strength;
                rb2d.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCooldown(rb2d));
            }
        } else {
            if (other.gameObject.CompareTag("Player")) {
                Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
                if (rb2d != null)
                {
                    Vector2 difference = ((rb2d.transform.position - transform.position).normalized) * strength;
                    rb2d.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCooldown(rb2d));
                }
            }
        }
    }


    private IEnumerator KnockCooldown(Rigidbody2D rb2d)
    {

        if(rb2d != null)
        {
            yield return new WaitForSeconds(delay);
            rb2d.velocity = Vector2.zero;
        }

    }
}
