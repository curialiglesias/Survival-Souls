using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float kbforce = 20f;
    public float kbStunTime;

    private Rigidbody2D rb2d;
    private Animator playerAnimator;
    private AudioSource audioSource;

    private Vector2 moveInput;
    private bool canMove;

    private FreezingController freezingController;
    private SimpleFlash simpleFlash;

    private bool isDashing = false;
    public float dashDuration = 0.001f;
    public float dashCooldown = 0.01f;

    private float dashCounter;
    private float dashCoolCounter;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        canMove = true;
        freezingController = GetComponent<FreezingController>();
        simpleFlash = GetComponent<SimpleFlash>();
        audioSource = GetComponent<AudioSource>();
        speed = speed * (1 + JSONSaving.SharedInstance.playerData.velocity * 0.25f);
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
        if (!moveInput.Equals(Vector2.zero) && !isDashing)
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

        // Dash controller
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!isDashing && dashCoolCounter <= 0)
            {
                isDashing = true;
                dashCoolCounter = dashCooldown;
                dashCounter = dashDuration;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
        } else {
            if (isDashing) {
                isDashing = false;
            }
        }
    }

    IEnumerator DisableDashAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float currentSpeed = freezingController.isActive ? speed / 3f : speed;

            if (isDashing)
            {
                currentSpeed *= 5f;
            }

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
            if (enemy.GetComponent<Enemy>() != null)
            {
                enemy.GetComponent<Enemy>().canMove = false;
                GetComponent<PlayerLife>().HP -= enemy.GetComponent<Enemy>().damage;
            }
            if (enemy.GetComponent<Spikes>() != null)
            {
                GetComponent<PlayerLife>().HP -= enemy.GetComponent<Spikes>().damage;
            }
            if (enemy.GetComponent<RockBehavior>() != null)
            {
                GetComponent<PlayerLife>().HP -= enemy.GetComponent<RockBehavior>().damage;
            }
            if (enemy.GetComponent<AudioSource>() != null && enemy.GetComponent<RockBehavior>() == null)
            {
                int randomSound = Random.Range(1, 10);
                if (randomSound > 0 && randomSound < 8)
                {
                    enemy.GetComponent<AudioSource>().Play();
                }
            }
                
            StartCoroutine(KnockbackStunTime(kbStunTime, collision));

            simpleFlash.Flash();

        }
    }

    IEnumerator KnockbackStunTime(float cooldown, Collision2D collision)
    {
        var enemy = collision.collider.gameObject.GetComponent<Enemy>();

        yield return new WaitForSeconds(cooldown);
        canMove = true;

        yield return new WaitForSeconds(cooldown + 3f);
        if (enemy != null && enemy.TryGetComponent(out Enemy enemyComponent))
        {
            enemy.canMove = true;
        }
    }

}