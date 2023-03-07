using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceColliderSpawner : MonoBehaviour
{
    public GameObject iceColliderPrefab;

    private float spawnRate = 0.5f;
    private float despawnTime = 8f;
    private float spawnTimer = 0f;

    private List<GameObject> activeIceColliders = new List<GameObject>();

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
        GameObject iceCollider = ObjectPools.SharedInstance.GetPooledObject("IceCollider");

        if (iceCollider != null)
        {
            iceCollider.SetActive(true);
            iceCollider.transform.position = transform.position;

            activeIceColliders.Add(iceCollider);

            StartCoroutine(DeactivateAfterTime(iceCollider, despawnTime));
        }
    }

    IEnumerator DeactivateAfterTime(GameObject iceCollider, float time)
    {
        yield return new WaitForSeconds(time);

        activeIceColliders.Remove(iceCollider);

        iceCollider.SetActive(false);
    }

    void OnDisable()
    {
        DeactivateAllIceColliders();
    }

    void DeactivateAllIceColliders()
    {
        foreach (GameObject iceCollider in activeIceColliders)
        {
            iceCollider.SetActive(false);
        }

        activeIceColliders.Clear();
    }
}
