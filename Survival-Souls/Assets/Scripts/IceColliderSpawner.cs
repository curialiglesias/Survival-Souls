using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceColliderSpawner : MonoBehaviour
{
    public GameObject iceColliderPrefab;

    private float spawnRate = 0.5f;
    private float despawnTime = 10f;
    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnIceCollider();
            spawnTimer = 0f;
        }
    }

    void SpawnIceCollider()
    {
        Debug.Log("Ice Spawned");
        GameObject iceCollider = ObjectPools.SharedInstance.GetPooledObject("IceCollider");

        if (iceCollider != null)
        {
            iceCollider.SetActive(true);
            iceCollider.transform.position = transform.position;

            StartCoroutine(DeactivateAfterTime(iceCollider, despawnTime));
        }
    }

    IEnumerator DeactivateAfterTime(GameObject iceCollider, float time)
    {
        yield return new WaitForSeconds(time);
        iceCollider.SetActive(false);
    }
}
