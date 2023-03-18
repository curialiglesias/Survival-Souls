using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGolem : Enemy
{
    
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float shootingDistance = 10f;
    [SerializeField] private float shootInterval = 4f;

    private List<GameObject> enemyRocks = new List<GameObject>();
    private Transform aim;
    private Transform firePoint;
    private float _lastShootTime;

    protected override void Start()
    {
        base.Start();
        aim = transform.Find("Aim");
        firePoint = aim.Find("FirePoint");
    }

    protected override void Update()
    {
        base.Update();
        if (distanceToPlayer.magnitude <= shootingDistance && Time.time - _lastShootTime >= shootInterval)
        {
            float angle = Mathf.Atan2(distanceToPlayer.y, distanceToPlayer.x) * Mathf.Rad2Deg;
            aim.rotation = Quaternion.Euler(0, 0, angle);
            //firePoint.localRotation = Quaternion.identity;
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            Shoot();
            _lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject rock = ObjectPools.SharedInstance.GetPooledObject("EnemyRock");
        if (rock == null) return;
        rock.transform.position = firePoint.position;
        rock.transform.rotation = firePoint.rotation;
        rock.SetActive(true);
        enemyRocks.Add(rock);
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.AddForce(distanceToPlayer.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        foreach (GameObject rock in enemyRocks)
        {
            rock.SetActive(false);
            rock.GetComponent<RockBehavior>().rb.isKinematic = false;
            rock.GetComponent<RockBehavior>().rb.gravityScale = 0f;
        }
        enemyRocks.Clear();
    }
}
