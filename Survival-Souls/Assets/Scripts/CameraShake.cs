using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake instance;

    private float ShakeTimeRemaining, ShakePower, ShakeFadeTime, ShakeRotation;

    public float RotationMultiplier = 2f;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(ShakeTimeRemaining > 0)
        {
            ShakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-.01f, .01f);
            float yAmount = Random.Range(-.01f, .01f);

            transform.position = transform.position + new Vector3(xAmount, yAmount, 0);
            //disminucio gradual del shake
            ShakePower = Mathf.MoveTowards(ShakePower, 0f, ShakeFadeTime*Time.deltaTime);

            ShakeRotation = Mathf.MoveTowards(ShakeRotation, 0f, ShakeFadeTime * RotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, ShakeRotation * Random.Range(-1f, 1f));
    }

    public void StartShake(float length, float power)
    {
        ShakeTimeRemaining = length;
        ShakePower = power;

        ShakeFadeTime = power/length;
        ShakeRotation = power * RotationMultiplier;
    }
}
