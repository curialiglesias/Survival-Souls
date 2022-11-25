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
        Vector2 enemyRotation = (player.transform.position - transform.position).normalized;
        //Debug.Log(enemyRotation);

        // Set Animation parameters
        enemyAnimator.SetFloat("Horizontal", enemyRotation.x);
        enemyAnimator.SetFloat("Vertical", enemyRotation.y);
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
