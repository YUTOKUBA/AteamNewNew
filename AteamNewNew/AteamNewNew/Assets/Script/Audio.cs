using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    bool music_swich = false;

    private AudioSource music;
    public AudioSource audioSource;
    // public AudioClip BGM;
    // Start is called before the first frame update

    void Start()
    {
        audioSource.Play();
        //music.Play();
        //music = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (music_swich == false)
            {
                audioSource.Pause();
                music_swich = true;
            }
            else
            {
                music_swich = false;
                audioSource = this.GetComponent<AudioSource>();
                audioSource.UnPause();
            }
        }
    }
}

