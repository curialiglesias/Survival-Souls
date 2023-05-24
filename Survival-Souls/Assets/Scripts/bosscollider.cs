using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.HP--;
    }
}
