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

    private Vector3 randomDir;
    private Vector3 startPosition;

    protected GameObject player;
    protected NavMeshAgent agent;
    protected Animator enemyAnimator;

    protected virtual void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        startPosition = transform.position;
        GetRandomDir();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    protected virtual void Update()
    {
        distanceToPlayer = (player.transform.position - transform.position);

        if (canMove)
        {
            if (distanceToPlayer.magnitude > 3)
            {
                if(Vector3.Distance(startPosition, randomDir) < 1f)
                {
                    Roam();
                }
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
        Debug.Log(transform.position);
        Debug.Log(randomDir);
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

    public void GetRandomDir()
    {
        Vector3 aux = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        randomDir = startPosition + (aux * UnityEngine.Random.Range(-2f, 2f));
    }

}
