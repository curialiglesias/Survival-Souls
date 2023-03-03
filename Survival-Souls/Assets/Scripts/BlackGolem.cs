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

    private IEnumerator FloorSpikes(float delay, Vector2 distanceBetween, Vector2 enemyPos)
    {
        GameObject spikes = ObjectPools.SharedInstance.GetPooledObject("EnemySpike");



        if (spikes != null)
        {
            yield return new WaitForSeconds(delay);
            spikes.transform.position = new Vector3(enemyPos.x + (distanceBetween.x)/*+ (distanceBetween.x * i)*/, enemyPos.y + (distanceBetween.y)/*+ (distanceBetween.y * i)*/, 0);
            spikes.SetActive(true);
            i++;
            StartCoroutine(FloorSpikes(delay, distanceBetween, enemyPos));
        }
    }
}
