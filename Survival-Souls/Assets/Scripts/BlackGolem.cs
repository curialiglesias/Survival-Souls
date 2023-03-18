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
    private int spikeCounter = 5;

    public Cooldowns spikeCooldown = new(20);


    protected override void TrackPlayer()
    {
        base.TrackPlayer();
        
        if (spikeCooldown.Wait()){

            spikeCounter = 5;
            StartCoroutine(SpawnSpikes());
        }
        
    }

    private IEnumerator SpawnSpikes()
        {
        if (spikeCounter == 0)
        {
            yield break;
        }
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");
        GameObject SpikeWarning = ObjectPools.SharedInstance.GetPooledObject("spikeWarning");
  
        x = player.transform.position.x;
        y = player.transform.position.y;

        if (spikes != null)
        {

            SpikeWarning.transform.position = new Vector3(x, y, 0);
            SpikeWarning.SetActive(true);
            yield return new WaitForSeconds(spikeDelay);
            spikes.transform.position = new Vector3(x, y, 0);
            SpikeWarning.SetActive(false);
            spikes.SetActive(true);
            spikeCounter = spikeCounter - 1;
            StartCoroutine(SpawnSpikes());
            yield return new WaitForSeconds(spikeInactive);
            spikes.SetActive(false);
        }
    }
}
