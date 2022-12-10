using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour
{


    public Transform FirePoint;


    public float bulletSpeed = 20f;

    // Update is called once per frame

    void Update()
    {

        if (Input.GetButtonUp("Fire1"))
        {
            shot();
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
            }


        }

        /*void chargeShot()
        {
            GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.right * bulletSpeed * 2, ForceMode2D.Impulse);
            bullet.transform.localScale = bullet.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        }

        /*void supershot()
        {
            GameObject superbullet = Instantiate(SuperBullet, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = superbullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.right * bulletSpeed, ForceMode2D.Impulse);
        }
        */

    }


