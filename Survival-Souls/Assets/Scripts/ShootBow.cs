using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour
{
    public Transform FirePoint;
    public float bulletSpeed = 5f;

    private SpriteRenderer spriteRenderer;
    private Color chargedColor = new Color(1f, 0.7f, 0f, 1.0f);

    private bool shotCharged = false;
    private float chargeTime = 0f;
    private float chargeDuration = 3f;

    private bool doubleShotUnlocked = false;
    private bool chargedShotUnlocked = false;

    private AudioSource chargedSoundAudioSource;
    private bool playSound = false;

    private FreezingController freezingController;

    void Start()
    {
        doubleShotUnlocked = JSONSaving.SharedInstance.LoadData().doubleShot;
        chargedShotUnlocked = JSONSaving.SharedInstance.LoadData().chargedShot;
        spriteRenderer = GetComponent<SpriteRenderer>();
        chargedSoundAudioSource = GameObject.Find("ChargedSound").GetComponent<AudioSource>();
        freezingController = GetComponent<FreezingController>();
    }

    void Update()
    {
        if (chargedShotUnlocked)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                chargeTime = 0f;
                playSound = true;
            }

            if (Input.GetButton("Fire1"))
            {
                chargeTime += Time.deltaTime;
                if (!freezingController.isActive)
                {
                    spriteRenderer.color = Color.Lerp(Color.white, chargedColor, chargeTime / chargeDuration);
                }
                
                if (chargeTime >= chargeDuration)
                {
                    shotCharged = true;
                }
            }
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            if (shotCharged)
            {
                shotCharged = false;
                spriteRenderer.color = Color.white;
                chargedShot();
                chargedSoundAudioSource.Stop();
            } else {
                shot();
                if (doubleShotUnlocked)
                {
                    Invoke("shot", 0.1f);
                }
            }
        }

        if (shotCharged && playSound)
        {
            chargedSoundAudioSource.Play();
            playSound = false;
        }
    }

    void shot()
    {
        GameObject arrow = ObjectPools.SharedInstance.GetPooledObject("Arrow");
            
        if (arrow != null)
        {
            arrow.SetActive(true);
            arrow.transform.position = FirePoint.position;
            arrow.transform.rotation = FirePoint.rotation;
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.right * bulletSpeed, ForceMode2D.Impulse);
            arrow.GetComponent<AudioSource>().Play();
        }
    }

    void chargedShot()
    {
        GameObject chargedArrow = ObjectPools.SharedInstance.GetPooledObject("chargedArrow");

        if (chargedArrow != null)
        {
            chargedArrow.SetActive(true);
            chargedArrow.transform.position = FirePoint.position;
            chargedArrow.transform.rotation = FirePoint.rotation;
            Rigidbody2D rb = chargedArrow.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.right * bulletSpeed / 2, ForceMode2D.Impulse);
            chargedArrow.GetComponent<AudioSource>().Play();
        }
    }
}
