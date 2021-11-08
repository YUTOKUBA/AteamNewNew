using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
    AudioSource audioSource;
    float time;
    public AudioClip sound;
    public float Oneshotaudio;

    private void Start()
    {
        //Transform Oneshotausio=
        Oneshotaudio = 60f;
    }
    void OnCollisionEnter(Collision collision) {

       AudioSource.PlayClipAtPoint(sound, transform.position);
       
        //audioSource.time = 60f;
        Debug.Log(Oneshotaudio);
    }

} 