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

    private float spikeDelay = 0f;
    public int spikeCounter = 0;
    Quaternion enemyRot;


    void Update()
    {
        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);

        if (canMove)
        {
            if (distanceToPlayer.magnitude > 2)
            {
                Roam();
            }else if (distanceToPlayer.magnitude < 2 && distanceToPlayer.magnitude < 1)
            {
                if(spikeCounter == 0)
                {
                    FloorSpikesOn(distanceToPlayer, playerPosition);
                }
            }
            else
            {
                agent.SetDestination(target.position);
                enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
                enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
                enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
            }
        }
    }
    public void FloorSpikesOn(Vector2 distanceToPlayer, Transform playerPosition)
    {

        spikeCounter = 5;

        enemyPos = transform.position;
        enemyRot = transform.rotation;
        StartCoroutine(SpawnSpikes(delay, distanceBetween, enemyPos, enemyRot, spikeCounter));
    }
    private IEnumerator SpawnSpikes(float delay, Vector2 distanceBetween, Vector2 enemyPos, Quaternion enemyRot, int spikeCounter)
    {
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");
        

        if (spikes != null)
        {
            spikes.transform.position = new Vector3(0, 0, 0);
            spikes.SetActive(true);
            i++;
            spikeCounter--;
            yield return new WaitForSeconds(spikeDelay);
            spikes.SetActive(false);
            StartCoroutine(SpawnSpikes(delay, distanceBetween, enemyPos, enemyRot, spikeCounter));
        }
    }
}
