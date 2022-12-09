using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] [Range(0f, 1f)] float chance = 1f;
    private Pool DropPool;

    void Start()
    {
        DropPool = Pool.Find("DropPool");
    }

    void OnDestroy()
    {
        if (Random.value < chance)
        {

            GameObject drop = DropPool.GetPooledObject();

            if (drop != null)
            {
                drop.SetActive(true);

                Transform t = drop.transform;
                t.position = transform.position;
            }
        }
        
    }

}
