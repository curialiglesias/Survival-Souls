using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    private float[] delays = { 3f, 7f };
    private int MaxEnemies = 15;
    private float low_tier_time = 20f;
    private float medium_tier_time = 60f;
    private float high_tier_time = 450f;
    private float boss_tier_time = 600f;
    private float timeStart;

    Transform maincam = GameObject.Find("MainCamera").GetComponent<Transform>();


    void Start()
    {
        timeStart = Time.time;
        StartCoroutine(spawnEnemy1(delays, timeStart));
    }

    private IEnumerator spawnEnemy1(float[] delay, float timeStart)
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
                    slime.transform.position = new Vector3(maincam.position.x - 50, maincam.position.y - 50, 0);
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
                    golem.transform.position = new Vector3(maincam.position.x - 50, maincam.position.y - 50, 0);
                    golem.SetActive(true);
                    StartCoroutine(spawnEnemy2(delay, timeStart));
                }
            }
        }
    }
}
