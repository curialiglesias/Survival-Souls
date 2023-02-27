using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackGolem : Enemy
{
    private float delay = 5f;
    private float x, y;

    public override void FloorSpikesOn(Vector2 distanceToPlayer)
    {
        //timeStart = Time.time;
        StartCoroutine(FloorSpikes(delay, distanceToPlayer));
    }

    private IEnumerator FloorSpikes(float delay, Vector2 distanceToPlayer)
    {
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");

        if (spikes != null)
        {
            yield return new WaitForSeconds(delay);
            spikes.transform.position = new Vector3(0, 0, 0);
            spikes.SetActive(true);
            StartCoroutine(FloorSpikes(delay, distanceToPlayer));
        }

    }
}
