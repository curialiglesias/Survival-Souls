using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    public GameObject player;


    void Start()
    {
    }


    public void Spawn()
    {

        GameObject enemy = GameObject.Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
        enemy.name = "Enemy";
        enemy.GetComponent<Enemy>().player = player;

    }
}
