using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.AI;
//using UnityEngine.Random;

[System.Serializable]



public class Spawner : MonoBehaviour
{
    public float delay = 2f;
    private int MaxEnemies = 15;
    private float low_tier_time = 20f;
    private float medium_tier_time = 120f;
    private float high_tier_time = 450f;
    private float boss_tier_time = 600f;
    private float timeStart;
    public int credit;
    private float x;
    private float y;
    private NavMeshTriangulation navMeshTriangulation;
    Vector3 playerPos;
    public static Spawner SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        //timeStart = Time.time;
        StartCoroutine(spawnEnemy(delay));
    }

    //String enemyTag
    public void creditGain(int addedCredit)
    {
        {
            credit += addedCredit;
        }
 
    }

    private IEnumerator spawnEnemy(float delay)
    {
        GameObject slime = ObjectPools.SharedInstance.GetPooledObject("SlimeEnemy");
        GameObject golem = ObjectPools.SharedInstance.GetPooledObject("GolemEnemy");
        if (slime != null && golem != null)
        {
            if (credit > 0 && credit <= 6)
            {
                yield return new WaitForSeconds(delay);
                x = UnityEngine.Random.Range(-7.0f, 8.0f);
                y = UnityEngine.Random.Range(-7.0f, 3.5f);
                slime.transform.position = new Vector3(x, y, 0);
                slime.SetActive(true);
                credit -= 1;
                StartCoroutine(spawnEnemy(delay));
            }else if (credit > 6)
            {
                yield return new WaitForSeconds(delay);
                x = UnityEngine.Random.Range(-7.0f, 8.0f);
                y = UnityEngine.Random.Range(-7.0f, 3.5f);
                golem.transform.position = new Vector3(x, y, 0);
                golem.SetActive(true);
                credit -= 5;
                StartCoroutine(spawnEnemy(delay));
            }
            else
            {
                yield return new WaitForSeconds(delay);
                StartCoroutine(spawnEnemy(delay));
            }
        }
    }
}
