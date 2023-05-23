using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public Vector2 transformdos;
    public Boolean firstDoor;
    public Quaternion rotationdos;
    private Quaternion resetRotation;
    private Vector3 resetDoor;

    private void Start()
    {
        resetDoor = transform.localPosition;

        resetRotation = transform.rotation;
    }

    public void DoorAction()
    {
        if (firstDoor)
        {
            gameObject.SetActive(true);
        }
        else
        {
            if (resetDoor != transform.localPosition)
            {
                gameObject.transform.localPosition = resetDoor;
                gameObject.transform.rotation = resetRotation;
            }
            else
            {

                gameObject.transform.localPosition = transformdos;
                gameObject.transform.rotation = rotationdos;
            }
        }
       
    }

}
