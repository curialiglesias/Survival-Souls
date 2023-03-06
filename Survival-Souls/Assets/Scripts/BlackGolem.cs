using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackGolem : Enemy
{
    private float x, y;
    private float spikeDelay = 1f;
    private float spikeInactive = 3f;
    public int spikeCounter = 0;
    public float Cooldown = 0;


    /*void Update()
    {




        /*if (canMove) {

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
    */

    public override void TrackPlayer()
    {


        if (Cooldown <= 0)
        {
            StartCoroutine(SpawnSpikes());
            Cooldown = 20;
        }
        else
        {
            Cooldown -= Time.deltaTime;
        }

        agent.SetDestination(target.position);
        enemyAnimator.SetFloat("Horizontal", distanceToPlayer.normalized.x);
        enemyAnimator.SetFloat("Vertical", distanceToPlayer.normalized.y);
        enemyAnimator.SetBool("Attack", distanceToPlayer.magnitude < 1);
    }

 

    private IEnumerator SpawnSpikes()
    {
        if (spikeCounter == 0)
        {
            spikeCounter = 5;
            yield break;
        }
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");
        GameObject SpikeWarning = ObjectPools.SharedInstance.GetPooledObject("spikeWarning");


        x = playerPosition.position.x;
        y = playerPosition.position.y;

        if (spikes != null)
        {

            SpikeWarning.transform.position = new Vector3(x, y, 0);
            SpikeWarning.SetActive(true);
            yield return new WaitForSeconds(spikeDelay);
            spikes.transform.position = new Vector3(x, y, 0);
            SpikeWarning.SetActive(false);
            spikes.SetActive(true);
            spikeCounter--;
            StartCoroutine(SpawnSpikes());
            yield return new WaitForSeconds(spikeInactive);
            spikes.SetActive(false);
        }
    }
}
