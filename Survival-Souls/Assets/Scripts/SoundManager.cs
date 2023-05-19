using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
