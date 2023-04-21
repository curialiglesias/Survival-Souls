
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class demonController : Enemy
{
    /*private Vector3 checkOrientation;
    private Vector3 checkPosition;
    private Vector3 randomDir;*/
    private UnityEngine.Vector2 moveInput;

    Animator enemyAnimatorRight, enemyAnimatorLeft, enemyAnimatorUp, enemyAnimatorDown;
    NavMeshAgent agentUp, agentDown, agentRight, agentLeft;

    GameObject up, down, right, left;
    protected override void Start()
    {
        right = GameObject.Find("rojo derecha 1");
        left = GameObject.Find("rojo izquierda 1");
        up = GameObject.Find("rojo arriba 1");
        down = GameObject.Find("rojo abajo 1");

        player = GameObject.Find("Player");
        enemyAnimatorRight = right.GetComponent<Animator>();
        enemyAnimatorLeft = left.GetComponent<Animator>();
        enemyAnimatorUp = up.GetComponent<Animator>();
        enemyAnimatorDown = down.GetComponent<Animator>();

        damage = damage / (1 + (JSONSaving.SharedInstance.playerData.defense * 0.25f));
        agentUp = up.GetComponent<NavMeshAgent>();
        agentDown = down.GetComponent<NavMeshAgent>();
        agentRight = right.GetComponent<NavMeshAgent>();
        agentLeft = left.GetComponent<NavMeshAgent>();

        agentUp.updateRotation = false;
        agentUp.updateUpAxis = false;
        agentDown.updateRotation = false;
        agentDown.updateUpAxis = false;
        agentRight.updateRotation = false;
        agentRight.updateUpAxis = false;
        agentLeft.updateRotation = false;
        agentLeft.updateUpAxis = false;
    }
    protected override void Update()
    {
        decideDemonPrefab();
    }


    void decideDemonPrefab()
    {


        distanceToPlayer = (player.transform.position - transform.position).normalized;


        Debug.Log(distanceToPlayer);

        up.SetActive(false);
        down.SetActive(false);
        right.SetActive(false);
        left.SetActive(false);

        if (Mathf.Abs(distanceToPlayer.x) < Mathf.Abs(distanceToPlayer.y))
        {
            if (distanceToPlayer.y > 0)
            {
                up.SetActive(true);
                enemyAnimator = enemyAnimatorUp;
                agent = agentUp;
            }
            else
            {
                down.SetActive(true);
                enemyAnimator = enemyAnimatorDown;
                agent = agentDown;
            }
        }
        else
        {
            if (distanceToPlayer.x < 0)
            {
                left.SetActive(true);
                enemyAnimator = enemyAnimatorLeft;
                agent = agentLeft;
            }
            else
            {
                right.SetActive(true);
                enemyAnimator = enemyAnimatorDown;
                agent = agentRight;
            }
        }
    }

    protected override void Roam()
    {

    }


    protected override void TrackPlayer()
    {
    }



}
