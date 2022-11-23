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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
