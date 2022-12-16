using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    private float[] delays = { 3f, 7f };
    private int MaxEnemies = 15;
    private float low_tier_time = 200f;
    private float medium_tier_time = 300f;
    private float high_tier_time = 450f;
    private float boss_tier_time = 600f;
    private float timeStart;
    Vector3 playerPos;


    void Start()
    {
        timeStart = Time.time;
        StartCoroutine(spawnEnemy1(delays, timeStart));
    }


    private void Update()
    {
         playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    private IEnumerator spawnEnemy1(float[] delay, float timeStart)
    {
        GameObject slime = ObjectPools.SharedInstance.GetPooledObject("SlimeEnemy");
        if (slime != null)
        {
            if (Time.time - timeStart <= low_tier_time)
            {

                yield return new WaitForSeconds(delay[0]);
                slime.transform.position = new Vector3(playerPos.x - 1, playerPos.y - 1, 0);
                slime.SetActive(true);
                StartCoroutine(spawnEnemy1(delay, timeStart));
                
            }
            else
            {
                StartCoroutine(spawnEnemy2(delay, timeStart));
            }
        }
    }

    private IEnumerator spawnEnemy2(float[] delay, float timeStart)
    {
        GameObject golem = ObjectPools.SharedInstance.GetPooledObject("GolemEnemy");
        if (golem != null) {
            if (Time.time - timeStart > low_tier_time && Time.time - timeStart <= medium_tier_time)
            {
                yield return new WaitForSeconds(delay[1]);
                golem.transform.position = new Vector3(playerPos.x - 1, playerPos.y - 1, 0);
                golem.SetActive(true);
                StartCoroutine(spawnEnemy2(delay, timeStart));
              
            }
        }
    }
}
