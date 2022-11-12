using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update


    private RenderLine linecontroller;
    private int HP = 5;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Arrow(Clone)")
        {
            HP = HP - 1;
            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }


        if (collision.gameObject.name == "SuperBullet(Clone)")
        {
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 1.5f, 64);

            List<Transform> enemyPositions = new List<Transform>();
            
            for (int i = 0; i < hitColliders.Length; i++)
            {
                enemyPositions.Add(hitColliders[i].transform);
            }
            Debug.Log(enemyPositions.Count);

            linecontroller = GameObject.FindGameObjectWithTag("RenderLine").GetComponent<RenderLine>();

            for (int i = 0; i < enemyPositions.Count; i++)
            {
                Debug.Log(enemyPositions[i].transform);
            }
            linecontroller.setupLine(enemyPositions);


            }
            

        }
    }
    
