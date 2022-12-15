using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator playerAnimator;
    private Vector2 moveInput;

    public float speed;

    public float kbforce = 20f;
    public float kbStunTime;

    bool canMove;

 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        canMove = true;
    }

    void Update()
    {

        // WASD input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        // Mouse input
        Vector2 mousePosAux = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = (mousePosAux - new Vector2(transform.position.x, transform.position.y)).normalized;
        float mouseX = mousePos.x;
        float mouseY = mousePos.y;

        // Set Animation parameters
        playerAnimator.SetFloat("Horizontal", mouseX);
        playerAnimator.SetFloat("Vertical", mouseY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rb2d.MovePosition(rb2d.position + moveInput * speed * Time.fixedDeltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Contains("Enemy"))
        {
            Vector2 dir = ((transform.position - collision.transform.position).normalized) * kbforce;
            canMove = false;
            rb2d.AddForce(dir, ForceMode2D.Impulse);
            StartCoroutine(KnockbackStunTime(kbStunTime));
        }
    }

    IEnumerator KnockbackStunTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canMove = true;
    }

}
