using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    public void Drop()
    {
        if (Random.value <= chance)
        {
            Debug.Log(chance);
            GameObject drop = ObjectPools.SharedInstance.GetPooledObject("Drop");

            if (drop != null)
            {
                drop.SetActive(true);

                Transform t = drop.transform;
                t.position = transform.position;
            }
        }
    }

}
