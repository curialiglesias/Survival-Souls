using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGolemsMap2 : MonoBehaviour
{
    private float delay = 2;
    private float x, y;
    private float i = 0;
    private int randomSpawn;
    public static Spawner SharedInstance;


    void Start()
    {
        StartCoroutine(spawnEnemy(delay));
    }

    private void setActiveGolems(GameObject golem, GameObject golemIce, GameObject golemRock)
    {

        randomSpawn = Random.Range(1, 4);

        switch (i)
        {
            case 0:

                x = -36.35f;
                y = 0.35f;

                if (randomSpawn == 1)
                {
                    golem.transform.position = new Vector3(x, y, 0);
                    golem.SetActive(true);
                }
                else if (randomSpawn == 2)
                {
                    golemIce.transform.position = new Vector3(x, y, 0);
                    golemIce.SetActive(true);
                }
                else
                {
                    golemRock.transform.position = new Vector3(x, y, 0);
                    golemRock.SetActive(true);
                }

                break;


            case 1:

                x = -36.35f;
                y = -1.75f;

                if (randomSpawn == 1)
                {
                    golem.transform.position = new Vector3(x, y, 0);
                    golem.SetActive(true);
                }
                else if (randomSpawn == 2)
                {
                    golemIce.transform.position = new Vector3(x, y, 0);
                    golemIce.SetActive(true);
                }
                else
                {
                    golemRock.transform.position = new Vector3(x, y, 0);
                    golemRock.SetActive(true);
                }


                break;
            case 2:

                x = -26.2f;
                y = -1.75f;

                if (randomSpawn == 1)
                {
                    golem.transform.position = new Vector3(x, y, 0);
                    golem.SetActive(true);
                }
                else if (randomSpawn == 2)
                {
                    golemIce.transform.position = new Vector3(x, y, 0);
                    golemIce.SetActive(true);
                }
                else
                {
                    golemRock.transform.position = new Vector3(x, y, 0);
                    golemRock.SetActive(true);
                }

                break;



            case 3:

                x = -26.2f;
                y = 0.35f;

                if (randomSpawn == 1)
                {
                    golem.transform.position = new Vector3(x, y, 0);
                    golem.SetActive(true);
                }
                else if (randomSpawn == 2)
                {
                    golemIce.transform.position = new Vector3(x, y, 0);
                    golemIce.SetActive(true);
                }
                else
                {
                    golemRock.transform.position = new Vector3(x, y, 0);
                    golemRock.SetActive(true);
                }

                break;


        }

        i++;
        if(i > 3)
        {
            i = 0;
        }

       
    }

    private IEnumerator spawnEnemy(float delay)
    {
        GameObject golem = ObjectPools.SharedInstance.GetPooledObject("GolemEnemy");
        GameObject golemIce = ObjectPools.SharedInstance.GetPooledObject("GolemiceEnemy");
        GameObject golemRock = ObjectPools.SharedInstance.GetPooledObject("GolemrockEnemy");


        if (golem != null && golemIce != null && golemRock != null)
        {
            setActiveGolems(golem, golemIce, golemRock);
            yield return new WaitForSeconds(4f);
            StartCoroutine(spawnEnemy(delay));

        }
        else
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(spawnEnemy(delay));
        }
    }
}
