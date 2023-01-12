using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform playerPosition;

    //private RenderLine linecontroller;
    public int HP;
    public int initialHP;
    public float damage;


    private Animator enemyAnimator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        playerPosition = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // Vector calculations relative to the player
        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);
        Vector2 enemyRotation = distanceToPlayer.normalized;
        float enemyDistance = distanceToPlayer.magnitude;


        // Set Animation parameters
        enemyAnimator.SetFloat("Horizontal", enemyRotation.x);
        enemyAnimator.SetFloat("Vertical", enemyRotation.y);

        enemyAnimator.SetBool("Attack", enemyDistance < 1);
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
