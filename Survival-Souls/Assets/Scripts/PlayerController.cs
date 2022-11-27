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

    /*public float kbf;
    public float kbStunTime;*/

    //bool canMove;

    //private bool wallTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        //canMove = true;
    }

    // Update is called once per frame
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
        //if (canMove)
        //{
            rb2d.MovePosition(rb2d.position + moveInput * speed * Time.fixedDeltaTime);
        //}
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 dir = ((transform.position - collision.gameObject.transform.position).normalized) * kbf;
            canMove = false;
            rb2d.AddForce(dir, ForceMode2D.Impulse);
            StartCoroutine(KnockbackStunTime(kbStunTime));
        }
    }

    IEnumerator KnockbackStunTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canMove = true;
    }*/

    /*void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 10;

        // If the object we hit is the enemy
        if (c.gameObject.tag == "Enemy")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }*/
}
