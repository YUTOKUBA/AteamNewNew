using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    AudioSource audiosource;

    private AudioClip sound;
    private AudioClip play;
    private bool flg;
    private int con;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        flg = false;
        con = 0;
    }
    private void Update()
    {
        if (flg == true)
        {
            audiosource.Play();
            con++;
            Debug.Log(con);
            if (con >= 60)
            {
                
               
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //audiosource.Stop();
            Destroy(gameObject);
            flg = false;
        }
    }
}