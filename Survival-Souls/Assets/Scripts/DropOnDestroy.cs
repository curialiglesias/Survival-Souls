using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    public GameObject itemToDrop;

    public void Drop()
    {
        int randomProbability = Random.Range(1, 10);
        if (randomProbability > 0 && randomProbability < 6)
        {
            GameObject drop = ObjectPools.SharedInstance.GetPooledObject(itemToDrop.name);

           

            if (drop != null)
            {
                Transform t = drop.transform;
                t.position = transform.position;

                drop.SetActive(true);
            }
        }
    }

}
