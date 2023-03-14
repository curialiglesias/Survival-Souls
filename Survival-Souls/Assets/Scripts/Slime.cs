using System.Collections;
using System.Collections.Generic;
//using Unity.Services.Analytics.Internal;
using UnityEngine;
//using Unity.Services.Core.Analytics;

public class Slime : Enemy
{
    public float scale = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SlimeEnemy")
        {

            collision.collider.gameObject.SetActive(false);

            Vector2 position = gameObject.transform.position;

            gameObject.SetActive(false);

            GameObject bigSlime = ObjectPools.SharedInstance.GetPooledObject("SuperSlimeEnemy");

            bigSlime.transform.localScale = new Vector2(scale, scale);
            bigSlime.transform.position = position;
            bigSlime.SetActive(true);
        }
    }
    
    public Vector2 GetClosestSlime(List<Transform> actives)
    {
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

        return new Vector2(actives[bestTarget].position.x, actives[bestTarget].position.y);

    }

    protected override void Roam()
    {
        base.Roam();
        InvokeRepeating("Fusion", 0f, 5f);
        
    }

    public void Fusion()
    {

        Vector2 randomDir = GetClosestSlime(ObjectPools.SharedInstance.GetActiveObjects("Slime"));
        agent.SetDestination(randomDir);
        enemyAnimator.SetFloat("Horizontal", randomDir.x);
        enemyAnimator.SetFloat("Vertical", randomDir.y);
    }

    private void OnDisable()
    {
        CancelInvoke("Fusion");
    }

}