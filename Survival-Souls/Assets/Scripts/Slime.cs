using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using UnityEngine;

public class Slime : Enemy
{
    public float scale = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Contains("Slime"))
        {
            collision.collider.gameObject.SetActive(false);
            Vector2 position = gameObject.transform.position;
            gameObject.SetActive(false);
            GameObject bigSlime = ObjectPools.SharedInstance.GetPooledObject("Slime");
            bigSlime.transform.localScale = new Vector2(scale, scale);
            var stats = bigSlime.GetComponent<Enemy>();
            stats.initialHP = 30;
            stats.damage = 30;
            bigSlime.transform.position = position;
            bigSlime.SetActive(true);
        }
    }

public Vector2 GetRandomDir(List<Transform> actives)
    {
        Debug.Log (actives.Count);
        int bestTarget = 0;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        for(int i = 0; i < actives.Count; i++)
        {

            float loopDistance = Vector3.Distance(transform.position, currentPosition);
            if(loopDistance  < closestDistanceSqr)
            {
                closestDistanceSqr = loopDistance;
                bestTarget = i;
            }
        }

        //return new Vector2(actives[bestTarget].position.x, actives[bestTarget].position.y);
        return new Vector2(1,1);
    }

    public override void Roam()
    {
        InvokeRepeating("Fusion", 0f, 5f);
        
    }

    public  void Fusion()
    {
        Vector2 randomDir = GetRandomDir(ObjectPools.SharedInstance.GetActiveObjects("Slime"));
        agent.SetDestination(randomDir);
        enemyAnimator.SetFloat("Horizontal", randomDir.x);
        enemyAnimator.SetFloat("Vertical", randomDir.y);
    }


}