using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
    AudioSource audioSource;

    public AudioClip sound;
    
     void OnCollisionEnter(Collision collision) {
       AudioSource.PlayClipAtPoint(sound, transform.position);
     }
}