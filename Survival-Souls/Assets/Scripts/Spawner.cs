using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    private float[] delays = { 5f, 7f };
    private int MaxEnemies = 15;
    private float low_tier_time = 20f;
    private float medium_tier_time = 60f;
    private float high_tier_time = 450f;
    private float boss_tier_time = 600f;
    private float timeStart;

    void Start()
    {
        timeStart = Time.time;
        StartCoroutine(spawnEnemy1(EnemyPrefab, delays, timeStart));

    }

    private IEnumerator spawnEnemy1(GameObject[] EnemyPrefabs, float[] delay, float timeStart)
    {

        if (Time.time - timeStart <= low_tier_time)
        {
            if (MaxEnemies <= GameObject.FindGameObjectsWithTag("Enemy").Length)
            {
                yield return new WaitForSeconds(delay[0]);
                StartCoroutine(spawnEnemy1(EnemyPrefabs, delay, timeStart));
            }
            else
            {
                yield return new WaitForSeconds(delay[0]);
                GameObject enemy = Instantiate(EnemyPrefabs[0], new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1), 0) ,Quaternion.identity);
                StartCoroutine(spawnEnemy1(EnemyPrefabs, delay, timeStart));
            }

        }
        else
        {
            StartCoroutine(spawnEnemy2(EnemyPrefabs, delay, timeStart));
        }

    }

    private IEnumerator spawnEnemy2(GameObject[] EnemyPrefabs, float[] delay, float timeStart)
    {
        if (Time.time - timeStart > low_tier_time && Time.time - timeStart <= medium_tier_time)
        {
            if (MaxEnemies <= GameObject.FindGameObjectsWithTag("Enemy").Length)
            {
                yield return new WaitForSeconds(delay[1]);
                StartCoroutine(spawnEnemy2(EnemyPrefabs, delay, timeStart));
            }
            else
            {
                yield return new WaitForSeconds(delay[1]);
                GameObject enemy = Instantiate(EnemyPrefabs[1], new Vector3(Random.Range(-0f, 0), Random.Range(-0f, 0), 0), Quaternion.identity);
                StartCoroutine(spawnEnemy2(EnemyPrefabs, delay, timeStart));
            }
        }

    }
}
