using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float MovementSpeed = 5f;

    public Rigidbody2D Rigidbody;
    public Camera cam;

    Vector2 movement;
    Vector2 mousepos;
    
    void Update()
    {
       movement.x =  Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + movement * MovementSpeed * Time.fixedDeltaTime );

        Vector2 lookat = mousepos - Rigidbody.position;
        float angle = Mathf.Atan2( lookat.y, lookat.x ) * Mathf.Rad2Deg - 90f;
        Rigidbody.rotation = angle;
    }
}
