using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackGolem : Enemy
{
    private float delay = 3f;
    private float x, y;
    private Vector2 distanceBetween, enemyPos;
    private int i = 1;

    private float spikeDelay = 1f;
    public int spikeCounter = 0;
    private Vector2 positionIteration;
    Quaternion enemyRot;


    void Update()
    {
        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);
        if (canMove)
        {
            if (distanceToPlayer.magnitude < 2 && distanceToPlayer.magnitude < 1)
            {
                if(spikeCounter == 0)
                {
                    spikeCounter = 5;
                    StartCoroutine(SpawnSpikes(delay, distanceBetween, spikeCounter));
                }
            }
        }
    }
    private IEnumerator SpawnSpikes(float delay, Vector2 distanceBetween, int spikeCounter)
    {
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");
        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);

        enemyPos = transform.position;
        enemyRot = transform.rotation;

        if (enemyRot.eulerAngles.x >= 30 && enemyRot.eulerAngles.x >= -30)
        {

        }else if (enemyRot.eulerAngles.x > 30 && enemyRot.eulerAngles.x >= -30)
        {

        }




        positionIteration = distanceToPlayer / 5;

        if (spikes != null)
        {
            spikes.transform.position = new Vector3(0, 0, 0);
            spikes.SetActive(true);
            i++;
            spikeCounter--;
            yield return new WaitForSeconds(spikeDelay);
            spikes.SetActive(false);
            StartCoroutine(SpawnSpikes(delay, distanceBetween, spikeCounter));
        }
    }
}
