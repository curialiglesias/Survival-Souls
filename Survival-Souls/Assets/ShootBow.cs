using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour
{
    

    public Transform FirePoint;
    public GameObject Bullet;
    public GameObject SuperBullet;
    private float chargeTime;

    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
        }

        if(chargeTime > 2)
        {
            //playsound
            if (Input.GetButtonUp("Fire1"))
            {
                chargeShot();
                chargeTime = 0;
            }
        }

        else
        {
            if (Input.GetButtonUp("Fire1"))
            {
                shot();
                chargeTime = 0;
            }
        }

        if (Input.GetButtonDown("Special"))
        {
            supershot();
        }


        void shot()
        {
            GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletSpeed, ForceMode2D.Impulse);

        }

        void chargeShot()
        {
            GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletSpeed * 2, ForceMode2D.Impulse);
            bullet.transform.localScale = bullet.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        }

        void supershot()
        {
            GameObject superbullet = Instantiate(SuperBullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = superbullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }


    }
}
