using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    public GameObject itemToDrop;
    [Range(0f, 1f)]
    public float chance = 1f;

    public void Drop()
    {
        if (Random.value <= chance)
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
