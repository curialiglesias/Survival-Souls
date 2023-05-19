using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGolem : Enemy
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float attackTime = 0.5f;
    [SerializeField] private float shootingDistance = 2f;
    [SerializeField] private float shootInterval = 2f;

    private List<GameObject> enemyRocks = new List<GameObject>();
    private Transform aim;
    private Transform firePoint;
    private float _lastShootTime;
    private bool _isAttacking = false;
    private float _attackTimer = 0f;

    protected override void Start()
    {
        base.Start();
        aim = transform.Find("Aim");
        firePoint = aim.Find("FirePoint");
    }

    protected override void Update()
    {
        base.Update();
        if (!_isAttacking && distanceToPlayer.magnitude <= shootingDistance && (Time.time - _lastShootTime) >= shootInterval)
        {
            float angle = Mathf.Atan2(distanceToPlayer.y, distanceToPlayer.x) * Mathf.Rad2Deg;
            aim.rotation = Quaternion.Euler(0, 0, angle);
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            _isAttacking = true;
            _attackTimer = 0f;
            enemyAnimator.SetBool("Attack", true);
        }

        if (_isAttacking)
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer >= attackTime)
            {
                _isAttacking = false;
                enemyAnimator.SetBool("Attack", false);
                Shoot();
                _lastShootTime = Time.time;
            }
        }
    }

    protected override void TrackPlayer()
    {
        enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
        enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);

        if (distanceToPlayer.magnitude > shootingDistance)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
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
        //rock.GetComponent<AudioSource>().Play();
    }

    private void OnDisable()
    {
        foreach (GameObject rock in enemyRocks)
        {
            if (rock != null)
            {
                rock.SetActive(false);
                rock.GetComponent<RockBehavior>().rb.isKinematic = false;
                rock.GetComponent<RockBehavior>().rb.gravityScale = 0f;
            }
        }
        enemyRocks.Clear();
    }
}