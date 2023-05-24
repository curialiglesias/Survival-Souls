using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimedRoom : MonoBehaviour
{
    public int RoomLight = 0;
    public float delay = 2f;
    public float xmax, xmin, ymax, ymin;
    private float x, y;
    private int randomSpawn;
    public static Spawner SharedInstance;


    void Start()
    {
        StartCoroutine(spawnEnemy(delay));
        InvokeRepeating("TickLight", 10, 30);
    }

    // Update is called once per frame




    private void setActiveGolems(GameObject golem, GameObject golemIce, GameObject golemRock)
    {
        x = UnityEngine.Random.Range(xmin, xmax);
        y = UnityEngine.Random.Range(ymin, ymax);
        randomSpawn = UnityEngine.Random.Range(1, 4);

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
    }


    private void setActiveSlimes(GameObject slime)
    {
        x = UnityEngine.Random.Range(xmin, xmax);
        y = UnityEngine.Random.Range(ymin, ymax);
        slime.transform.position = new Vector3(x, y, 0);
        slime.SetActive(true);
    }


    private IEnumerator spawnEnemy(float delay)
    {
        GameObject slime = ObjectPools.SharedInstance.GetPooledObject("SlimeEnemy");
        GameObject golem = ObjectPools.SharedInstance.GetPooledObject("GolemEnemy");
        GameObject golemIce = ObjectPools.SharedInstance.GetPooledObject("GolemiceEnemy");
        GameObject golemRock = ObjectPools.SharedInstance.GetPooledObject("GolemrockEnemy");

        if (slime != null && golem != null && golemIce != null && golemRock != null)
        {

            if (RoomLight >= 0 && RoomLight < 5)
            {
                if (RoomLight >= 0 && RoomLight < 2)
                {
                    int randomProbability = UnityEngine.Random.Range(1, 10);
                    if (randomProbability > 0 && randomProbability < 2)
                    {
                        setActiveGolems(golem, golemIce, golemRock);
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(spawnEnemy(delay));
                    }
                    else
                    {
                        setActiveSlimes(slime);
                        yield return new WaitForSeconds(2f);
                        StartCoroutine(spawnEnemy(delay));
                    }

                }
                else if (RoomLight >= 2 && RoomLight < 5)
                {
                    int randomProbability = UnityEngine.Random.Range(1, 10);
                    if (randomProbability > 0 && randomProbability < 4)
                    {
                        setActiveGolems(golem, golemIce, golemRock);
                        yield return new WaitForSeconds(1.5f);
                        StartCoroutine(spawnEnemy(delay));
                    }
                    else
                    {
                        setActiveSlimes(slime);
                        yield return new WaitForSeconds(1.5f);
                        StartCoroutine(spawnEnemy(delay));
                    }
                }
            }
            else
            {
                yield return new WaitForSeconds(delay);

            }
        }
    }

    private void TickLight()
    {
        gameObject.transform.GetChild(RoomLight).gameObject.SetActive(false);
        RoomLight++;
        if(RoomLight == 5)
        {
            CancelInvoke();
        }
    }


}