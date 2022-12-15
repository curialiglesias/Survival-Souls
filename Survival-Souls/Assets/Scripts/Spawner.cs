using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    private float[] delays = { 3f, 7f };
    private int MaxEnemies = 15;
    private float low_tier_time = 20f;
    private float medium_tier_time = 60f;
    private float high_tier_time = 450f;
    private float boss_tier_time = 600f;
    private float timeStart;

    void Start()
    {
        timeStart = Time.time;
        StartCoroutine(spawnEnemy1(delays, timeStart));

    }

    private IEnumerator spawnEnemy1(/*GameObject[] EnemyLow*/float[] delay, float timeStart)
    {
        GameObject slime = ObjectPools.SharedInstance.GetPooledObject("SlimeEnemy");
        if (slime != null)
        {
            if (Time.time - timeStart <= low_tier_time)
            {
                if (MaxEnemies <= GameObject.FindGameObjectsWithTag("SlimeEnemy").Length)
                {
                    yield return new WaitForSeconds(delay[0]);
                    StartCoroutine(spawnEnemy1(delay, timeStart));
                }
                else
                {
                    yield return new WaitForSeconds(delay[0]);
                    //GameObject enemyGame = Instantiate(enemy);//, new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1), 0) ,Quaternion.identity);
                    slime.SetActive(true);
                    StartCoroutine(spawnEnemy1(delay, timeStart));
                }

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
                if (MaxEnemies <= GameObject.FindGameObjectsWithTag("GolemEnemy").Length)
                {
                    yield return new WaitForSeconds(delay[1]);
                    StartCoroutine(spawnEnemy2(delay, timeStart));
                }
                else
                {
                    yield return new WaitForSeconds(delay[1]);
                    golem.SetActive(true);
                    //GameObject enemy = Instantiate(EnemyPrefabs[1]);//, new Vector3(Random.Range(-0f, 0), Random.Range(-0f, 0), 0), Quaternion.identity);
                    StartCoroutine(spawnEnemy2(delay, timeStart));
                }
            }
  
        }

    }
}
