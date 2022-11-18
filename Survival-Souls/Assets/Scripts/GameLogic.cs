using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{


    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CreateEnemy()
    {
        spawner.Spawn();
    }
}
