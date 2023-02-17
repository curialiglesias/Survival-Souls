using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public float scale = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Contains("Slime"))
        {
            collision.collider.gameObject.SetActive(false);
            Vector2 position = gameObject.transform.position;
            gameObject.SetActive(false);
            GameObject bigSlime = ObjectPools.SharedInstance.GetPooledObject("Slime");
            bigSlime.transform.localScale = new Vector2(scale, scale);
            var stats = bigSlime.GetComponent<Enemy>();
            stats.initialHP = 30;
            stats.damage = 30;
            bigSlime.transform.position = position;
            bigSlime.SetActive(true);
        }
    }
}
