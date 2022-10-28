using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    private RenderLine linecontroller;

    private void OnCollisionEnter2D(Collision2D collision)
    {


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
    
