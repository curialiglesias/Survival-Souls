using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehabior : MonoBehaviour 
{
    private float timer;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Contains("Enemy")){
            
            var enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.HP--;


            if (enemy.HP <= 0)
            {
                DropOnDestroy drop = collider.gameObject.GetComponent<DropOnDestroy>();
                drop.Drop();
                collider.gameObject.SetActive(false);
                enemy.HP = enemy.initialHP;
                Spawner.SharedInstance.creditGain(20);
            }
            CameraShake.instance.StartShake(.2f, .1f);
        }

        gameObject.SetActive(false);
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
