using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackGolem : Enemy
{
    private float delay = 5f;
    private float x, y;
    private Vector2 distanceBetween, enemyPos;
    private int i;

    private float spikeDelay = 1f;
    private float spikeInactive = 3f;
    public int spikeCounter = 0;
    private Vector2 positionIteration;
    Quaternion enemyRot;
    public float Cooldown = 0;
    private float waitToStopTimer = 0;


    void Update()
    {

        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
        }

        if (Cooldown <= 15)
        {
            canMove = true;
            spikeCounter = 5;
        }
        else
        {
            canMove = false;
        }

        Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);

        if (distanceToPlayer.magnitude < 2 && distanceToPlayer.magnitude < 1.5)
        {
            if (Cooldown <= 0)
            {
                i = 0;
                waitToStop();
                StartCoroutine(SpawnSpikes(delay, distanceBetween, spikeCounter));
                Cooldown = 20;
            }
        }


        if (canMove) {

            if (distanceToPlayer.magnitude > 2) {
                Roam();
            }
            else {
                agent.SetDestination(target.position);
                enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
                enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
                enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
            }
        }
    }


    void waitToStop()
    {
        waitToStopTimer = 10f;
        do
        {
            waitToStopTimer --;
        } while (waitToStopTimer > 0);
    }

    private IEnumerator SpawnSpikes(float delay, Vector2 distanceBetween, int spikeCounter)
    {
        if (spikeCounter == 0)
        {
            yield break;
        }
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");
        /*Vector2 distanceToPlayer = (playerPosition.transform.position - transform.position);

        if (distanceToPlayer.x < 0)
        {
            distanceToPlayer.x = - distanceToPlayer.x;
        }

        if (distanceToPlayer.y < 0)
        {
            distanceToPlayer.y = - distanceToPlayer.y;
        }

        enemyRot = transform.rotation;
        enemyPos = transform.position;
        positionIteration = (distanceToPlayer / spikeCounter) * 2f;
        if(i == 5)
        {
            positionIteration = (distanceToPlayer / spikeCounter);
        }        
        /*if (i == 0){
            positionIteration = (distanceToPlayer / spikeCounter) * 2f;
        }else if (i > 0 && i < 5)
        {
            positionIteration = (distanceToPlayer / spikeCounter) * 1.5f;
        }
        else
        {
            positionIteration.x = (playerPosition.transform.position.x - enemyPos.x) * 1.2f;
            positionIteration.y = (playerPosition.transform.position.y - enemyPos.y) * 1.2f;
        }

        if ((playerPosition.transform.position.x - enemyPos.x) > 0 && (playerPosition.transform.position.y - enemyPos.y) > 0)
        {
            x = enemyPos.x + positionIteration.x;
            y = enemyPos.y + positionIteration.y;

        }
        else if ((playerPosition.transform.position.x - enemyPos.x) < 0 && (playerPosition.transform.position.y - enemyPos.y) > 0)
        {
            x = enemyPos.x - positionIteration.x;
            y = enemyPos.y + positionIteration.y;
        }
        else if ((playerPosition.transform.position.x - enemyPos.x) < 0 && (playerPosition.transform.position.y - enemyPos.y) < 0)
        {
            x = enemyPos.x - positionIteration.x;
            y = enemyPos.y - positionIteration.y;
        }
        else if ((playerPosition.transform.position.x - enemyPos.x) > 0 && (playerPosition.transform.position.y - enemyPos.y) < 0)
        {
            x = enemyPos.x + positionIteration.x;
            y = enemyPos.y - positionIteration.y;
        }

        if(x > 8.0f){
            x = 7.8f;
        }
        else if(x < -7.0f)
        {
            x = -6.8f;
        }

        if (y > 3.5f)
        {
            y = 3.3f;
        }
        else if (y < -7.0f)
        {
            y = -6.8f;
        }*/

        x = playerPosition.position.x;
        y = playerPosition.position.y;

        if (spikes != null)
        {
            yield return new WaitForSeconds(spikeDelay);
            spikes.transform.position = new Vector3(x, y, 0);
            spikes.SetActive(true);
            spikeCounter = spikeCounter - 1;
            i++;
            StartCoroutine(SpawnSpikes(delay, distanceBetween, spikeCounter));
            yield return new WaitForSeconds(spikeInactive);
            spikes.SetActive(false);
        }
    }
}
