using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject player;

    //private RenderLine linecontroller;
    public int HP = 5;

    private Animator enemyAnimator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Vector calculations relative to the player
        Vector2 distanceToPlayer = (player.transform.position - transform.position);
        Vector2 enemyRotation = distanceToPlayer.normalized;
        float enemyDistance = distanceToPlayer.magnitude;
        //Debug.Log(enemyDistance);

        // Set Animation parameters
        enemyAnimator.SetFloat("Horizontal", enemyRotation.x);
        enemyAnimator.SetFloat("Vertical", enemyRotation.y);
        enemyAnimator.SetFloat("Attack", enemyDistance);
    }

    public void attack()
    {

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
