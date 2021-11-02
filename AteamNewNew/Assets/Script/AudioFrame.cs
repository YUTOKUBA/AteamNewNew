using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFrame : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Stop();
            audioSource.Play();
        }
        //Debug.Log(audioSource.time);
    }
}