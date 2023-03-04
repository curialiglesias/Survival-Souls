using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabior : MonoBehaviour 
{
    private float timer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Drop"))
        {

        }
        else
        {
            if (collider.tag.Contains("Enemy")){

                if (!collider.tag.Contains("Spike"))
                {
                    var enemy = collider.gameObject.GetComponent<Enemy>();
                    enemy.HP--;

                    if (enemy.HP <= 0)
                    {
                        DropOnDestroy drop = collider.gameObject.GetComponent<DropOnDestroy>();
                        drop.Drop();

                        collider.gameObject.SetActive(false);

                        enemy.HP = enemy.initialHP;

                        if (collider.tag.Contains("Slime"))
                        {
                            Spawner.SharedInstance.creditGain(2);
                        }
                        else
                        {
                            Spawner.SharedInstance.creditGain(6);

                        }
                    }
                }
                CameraShake.instance.StartShake(.2f, .1f);
            }
            StartCoroutine(Deactivate(0.5f));
        }
    }

    IEnumerator Deactivate(float delay)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        timer += 1.0F * Time.deltaTime;

        if(timer > 5)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
