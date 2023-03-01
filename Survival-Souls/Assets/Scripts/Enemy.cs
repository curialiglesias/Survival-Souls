using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;


    [SerializeField] public NavMeshAgent agent;
    public bool canMove = true;
    private Transform playerPosition;

    //private RenderLine linecontroller;
    public int HP;
    public int initialHP;
    public float damage;

    private Vector2 randomDir;


    [SerializeField] public Animator enemyAnimator;

    void Start()
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
        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);

        if (canMove)
        {
            if (distanceToPlayer.magnitude > 2)
            {
                Roam();

            }else if (distanceToPlayer.magnitude < 2 && distanceToPlayer.magnitude > 1)
            {
                FloorSpikesOn(distanceToPlayer, playerPosition);
            }
            else
            {
                agent.SetDestination(target.position);
                enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
                enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
                enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
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


   public virtual void FloorSpikesOn(Vector2 distanceToPlayer, Transform playerPosition) {}


    public Vector2 GetRandomDir()
    {
        return new Vector2(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized;
    }





    /*Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 1.5f, 64);

           List<Transform> enemyPositions = new List<Transform>();

           for (int i = 0; i < hitColliders.Length; i++)
           {
               enemyPositions.Add(hitColliders[i].transform);
           }
           Debug.Log(enemyPositions.Count);

           linecontroller = GameObject.FindGameObjectWithTag("RenderLine").GetComponent<RenderLine>();

           for (int i = 0; i < enemyPositions.Count; i++)
           {
               Debug.Log(enemyPositions[i].transform);
           }
           linecontroller.setupLine(enemyPositions);
   */

}
