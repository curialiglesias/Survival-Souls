using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public bool canMove = true;
    public float HP;
    public int initialHP;
    public float damage;
    [HideInInspector] public Vector2 distanceToPlayer;

    protected Vector3 randomDir;
    protected Vector3 startPosition;
    protected Vector3 aux;

    protected GameObject player;
    protected NavMeshAgent agent;
    protected Animator enemyAnimator;
    protected Collider2D actualCollider;
    
    protected virtual void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        startPosition = transform.position;
        GetRandomDir();
        damage = damage / (1 + (JSONSaving.SharedInstance.playerData.defense * 0.25f));
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
                if(Vector3.Distance(transform.position, randomDir) < 1f)
                {
                    Roam();
                }
            }
            else
            {
                TrackPlayer();
            }
        }
    }

    protected virtual void Roam()
    {
        InvokeRepeating("GetRandomDir", 0f, 5f);
        agent.SetDestination(randomDir);
        if (this.tag.Contains("Demon"))
        {
            enemyAnimator.SetBool("Move", canMove);
        }
        else
        {
            enemyAnimator.SetFloat("Horizontal", randomDir.x);
            enemyAnimator.SetFloat("Vertical", randomDir.y);
        }
    }

    protected virtual void TrackPlayer()
    {
        agent.SetDestination(player.transform.position);
        if (this.tag.Contains("Demon")) {
            enemyAnimator.SetBool("Move", canMove);
            enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
        }
        else
        {
            enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
            enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
            enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);

        }
    }

    public void GetRandomDir()
    {
        aux = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        randomDir = startPosition + (aux * UnityEngine.Random.Range(-2f, 2f));
    }

}
