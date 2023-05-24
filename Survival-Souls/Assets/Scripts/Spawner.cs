using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public float delay = 2f;

    public int credit;
    private float x;
    private float y;
    private int randomSpawn;
    public static Spawner SharedInstance;
    private float time;


    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        time = Clock.SharedInstance.time;

        if (sceneName != "Map2")
        {
            StartCoroutine(spawnEnemy(delay));
        }


    }



    //String enemyTag
    public void creditGain(int addedCredit)
    {
        {
            credit += addedCredit;
        }
    }


    private void setActiveGolems(GameObject golem, GameObject golemIce, GameObject golemRock)
    {
        x = UnityEngine.Random.Range(-7.0f, 8.0f);
        y = UnityEngine.Random.Range(-7.0f, 3.5f);
        randomSpawn = UnityEngine.Random.Range(1, 4);

        

        if (randomSpawn == 1)
        {
            golem.transform.position = new Vector3(x, y, 0);
            golem.SetActive(true);
            credit -= 5;
        }
        else if (randomSpawn == 2)
        {
            golemIce.transform.position = new Vector3(x, y, 0);
            golemIce.SetActive(true);
            credit -= 5;
        }
        else
        {
            golemRock.transform.position = new Vector3(x, y, 0);
            golemRock.SetActive(true);
            credit -= 5;
        }
    }


    private void setActiveSlimes(GameObject slime)
    {
        x = Random.Range(-7.0f, 8.0f);
        y = Random.Range(-7.0f, 3.5f);
        slime.transform.position = new Vector3(x, y, 0);
        slime.SetActive(true);
        credit -= 1;
    }

    private IEnumerator spawnEnemy(float delay)
    {
        GameObject slime = ObjectPools.SharedInstance.GetPooledObject("SlimeEnemy");
        GameObject golem = ObjectPools.SharedInstance.GetPooledObject("GolemEnemy");
        GameObject golemIce = ObjectPools.SharedInstance.GetPooledObject("GolemiceEnemy");
        GameObject golemRock = ObjectPools.SharedInstance.GetPooledObject("GolemrockEnemy");

        time = Clock.SharedInstance.time;

        if (slime != null && golem != null && golemIce != null && golemRock != null)
        {
            if (credit > 0)
            {
                if (time < 120)
                {
                    int randomProbability = Random.Range(1, 10);
                    yield return new WaitForSeconds(delay);
                    if (credit > 20 && credit < 40)
                    {
                        if (randomProbability > 0 && randomProbability < 2)
                        {
                            setActiveGolems(golem, golemIce, golemRock);
                            StartCoroutine(spawnEnemy(delay));
                        }
                        else
                        {
                            setActiveSlimes(slime);
                            StartCoroutine(spawnEnemy(delay));
                        }
                    }
                    else if (credit > 40)
                    {
                        if (randomProbability > 0 && randomProbability < 4)
                        {
                            setActiveGolems(golem, golemIce, golemRock);
                            StartCoroutine(spawnEnemy(delay));
                        }
                        else
                        {
                            setActiveSlimes(slime);
                            StartCoroutine(spawnEnemy(delay));
                        }
                    }
                    else
                    {
                        setActiveSlimes(slime);
                        StartCoroutine(spawnEnemy(delay));
                    }
                }else if(time < 240 && time >= 120)
                {
                    int randomProbability = Random.Range(1, 10);
                    yield return new WaitForSeconds(delay);
                    if (credit > 10 && credit < 50)
                    {
                        if (randomProbability > 0 && randomProbability < 5)
                        {
                            setActiveGolems(golem, golemIce, golemRock);
                            StartCoroutine(spawnEnemy(delay));
                        }
                        else
                        {
                            setActiveSlimes(slime);
                            StartCoroutine(spawnEnemy(delay));
                        }
                    }
                    else if (credit > 50)
                    {
                        if (randomProbability > 0 && randomProbability < 7)
                        {
                            setActiveGolems(golem, golemIce, golemRock);
                            StartCoroutine(spawnEnemy(delay));
                        }
                        else
                        {
                            setActiveSlimes(slime);
                            StartCoroutine(spawnEnemy(delay));
                        }
                    }
                    else
                    {
                        setActiveSlimes(slime);
                        StartCoroutine(spawnEnemy(delay));
                    }

                }
                else
                {
                    int randomProbability = Random.Range(1, 10);
                    yield return new WaitForSeconds(delay);
                    if (credit > 5 && credit < 50)
                    {
                        if (randomProbability > 0 && randomProbability < 7)
                        {
                            setActiveGolems(golem, golemIce, golemRock);
                            StartCoroutine(spawnEnemy(delay));
                        }
                        else
                        {
                            setActiveSlimes(slime);
                            StartCoroutine(spawnEnemy(delay));
                        }
                    }
                    else if (credit > 50)
                    {
                        setActiveGolems(golem, golemIce, golemRock);
                        StartCoroutine(spawnEnemy(delay));
                    }
                    else
                    {
                        setActiveSlimes(slime);
                        StartCoroutine(spawnEnemy(delay));
                    }
                }
            }
            else
            {
                yield return new WaitForSeconds(delay);
                StartCoroutine(spawnEnemy(delay));
            }
        }
    }
}
