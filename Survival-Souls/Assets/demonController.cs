
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class demonController : Enemy
{
    /*private Vector3 checkOrientation;
    private Vector3 checkPosition;
    private Vector3 randomDir;*/
    private GameObject current;
    private UnityEngine.Vector2 moveInput;


    GameObject up, down, right, left;
    protected override void Start()
    {
        current = GameObject.Find("rojo derecha 1");
        player = GameObject.Find("Player");
        enemyAnimator = current.GetComponent<Animator>();
        damage = damage / (1 + (JSONSaving.SharedInstance.playerData.defense * 0.25f));
        agent = current.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    protected override void Update()
    {
        getCurrentGameObject();
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


    public void getCurrentGameObject()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new UnityEngine.Vector2(moveX, moveY).normalized;
        UnityEngine.Vector3 actualPosition = current.transform.position;
        current.SetActive(false);

        if ((moveInput.x >= - 0.71 || moveInput.x <= 0.71) && (moveInput.y >= 0.71))
        {
            current = GameObject.Find("rojo arriba 1");
        }
        else if((moveInput.x >= -0.71 || moveInput.x <= 0.71) && (moveInput.y <= - 0.71))
        {
            current = GameObject.Find("rojo abajo 1");
        }
        else if ((moveInput.y >= -0.71 || moveInput.y <= 0.71) && (moveInput.x >= 0.71))
        {
            current = GameObject.Find("rojo derecha 1");
        }
        else if ((moveInput.y >= -0.71 || moveInput.y <= 0.71) && (moveInput.x <= -0.71))
        {
            current = GameObject.Find("rojo izquierda 1");
        }
        current.transform.position = actualPosition;
        current.SetActive(true);

        enemyAnimator = current.GetComponent<Animator>();
        agent = current.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        Debug.Log(current);
    }

    override
    protected void TrackPlayer()
    {
        agent.SetDestination(player.transform.position);
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
