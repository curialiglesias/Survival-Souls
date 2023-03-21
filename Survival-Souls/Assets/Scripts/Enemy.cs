using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool canMove = true;
    public int HP;
    public int initialHP;
    public float damage;
    [HideInInspector] public Vector2 distanceToPlayer;

    private Vector2 randomDir;

    protected GameObject player;
    protected NavMeshAgent agent;
    protected Animator enemyAnimator;

    protected virtual void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        randomDir = GetRandomDir();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    protected virtual void Update()
    {
        distanceToPlayer = (player.transform.position - transform.position);

        if (canMove)
        {
            if (distanceToPlayer.magnitude > 5)
            {
                Roam();
            }else
            {
                TrackPlayer();
            }
        }
    }

    protected virtual void Roam()
    {
        InvokeRepeating("GetRandomDir", 0f, 5f);
        agent.SetDestination(randomDir);
        enemyAnimator.SetFloat("Horizontal", randomDir.x);
        enemyAnimator.SetFloat("Vertical", randomDir.y);
    }

    protected virtual void TrackPlayer()
    {
        agent.SetDestination(player.transform.position);
        enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
        enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
        enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
    }

    public Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized;
    }

}
