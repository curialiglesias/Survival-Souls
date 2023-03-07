using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator playerAnimator;
    private Vector2 moveInput;

    public float speed;

    public float kbforce = 20f;
    public float kbStunTime;

    private bool canMove;

    private FreezingController freezingController;

    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        canMove = true;
        freezingController = GetComponent<FreezingController>();
        audioSource = GetComponent<AudioSource>();
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

        //Play sound when moving
        if (!moveInput.Equals(Vector2.zero))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float currentSpeed = freezingController.isActive ? speed / 2f : speed;
            rb2d.MovePosition(rb2d.position + moveInput * currentSpeed * Time.fixedDeltaTime);
            audioSource.pitch = freezingController.isActive ? 1f : 1.3f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Contains("Enemy"))
        {
            Vector2 dir = ((transform.position - collision.transform.position).normalized) * kbforce;
            canMove = false;
            rb2d.AddForce(dir, ForceMode2D.Impulse);
            var enemy = collision.collider.gameObject;
            if (!collision.collider.tag.Contains("Spike"))
            {
                enemy.GetComponent<Enemy>().canMove = false;
                GetComponent<PlayerLife>().HP -= enemy.GetComponent<Enemy>().damage;
            }
            else
            {
                GetComponent<PlayerLife>().HP -= enemy.GetComponent<Spikes>().damage;
            }
            enemy.GetComponent<AudioSource>().Play();

            StartCoroutine(KnockbackStunTime(kbStunTime, collision));

        }
    }

    IEnumerator KnockbackStunTime(float cooldown, Collision2D collision)
    {
        var enemy = collision.collider.gameObject.GetComponent<Enemy>();

        yield return new WaitForSeconds(cooldown);
        canMove = true;
        

        
        yield return new WaitForSeconds(cooldown + 3f);
        if (!collision.collider.tag.Contains("Spike"))
        {
            enemy.canMove = true;
        }
    }

}
