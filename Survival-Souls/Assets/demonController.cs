using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonController : Enemy
{
    private Vector3 checkOrientation;
    private Vector3 checkPosition;
    private Vector3 randomDir;

    GameObject up, down, right, left;
    protected override void Start()
    {
        base.Start();

        startPosition = new Vector3(1,1,0);
        /*up = transform.Find("rojo arriba").gameObject;
        down = transform.Find("rojo abajo").gameObject;
        right = transform.Find("rojo derecha").gameObject;
        left = transform.Find("rojo izquierda").gameObject;

        up.transform.position = new Vector3(2f, 2f, 0);
        down.transform.position = new Vector3(2f, 2f, 0);
        right.transform.position = new Vector3(2f, 2f, 0);
        left.transform.position = new Vector3(2f, 2f, 0);

        down.SetActive(true);
        right.SetActive(true);
        left.SetActive(true);
        up.SetActive(true);*/
    }


    /*protected override void Roam()
    {
        InvokeRepeating("GetRandomDir", 0f, 5f);
        agent.SetDestination(randomDir);

        checkOrientation = aux - startPosition;

        enemyAnimator = up.GetComponent<Animator>();
        enemyAnimator.Play("walk_up_fast");

        /*if (checkOrientation.y < 0)
        {
            if (checkOrientation.y < 0)
            {

            }
            else
            {

            }

        }
        else
        {

        }

    }


    protected override void TrackPlayer()
    {
        agent.SetDestination(player.transform.position);

    }*/



}
