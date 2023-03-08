using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public NavMeshAgent agent;

    public bool canMove = true;
    public Transform playerPosition;

    //private RenderLine linecontroller;
    public int HP;
    public int initialHP;
    public float damage;

    private Vector2 randomDir;
    public Vector2 distanceToPlayer;


    [SerializeField] public Animator enemyAnimator;

    public virtual void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        playerPosition = GameObject.Find("Player").transform;
        randomDir = GetRandomDir();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        distanceToPlayer = (playerPosition.transform.position - transform.position);


        if (canMove)
        {
            if (distanceToPlayer.magnitude > 2)
            {
                Roam();
            }else
            {
                TrackPlayer();
            }
        }
    }

    public virtual void Roam()
    {
        InvokeRepeating("GetRandomDir", 0f, 5f);
        agent.SetDestination(randomDir);
        enemyAnimator.SetFloat("Horizontal", randomDir.x);
        enemyAnimator.SetFloat("Vertical", randomDir.y);
    }

    public virtual void TrackPlayer()
    {
        agent.SetDestination(target.position);
        enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
        enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
        enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
    }



    public Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized;
    }



}
