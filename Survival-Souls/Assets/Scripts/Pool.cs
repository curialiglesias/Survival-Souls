using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    private List<GameObject> pool = new List<GameObject>();
    public int amount = 20;
    private Pool instance;
    public GameObject objectToPool;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    { 
        for(int i = 0; i < amount ; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pool.Add(obj);

        }
        
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
               return pool[i];
            }
        }
        return null;
    }
}
