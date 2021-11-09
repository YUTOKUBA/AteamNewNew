using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {
    AudioSource audioSource;
    float time;
    //public AudioClip sound;
    public float Oneshotaudio,cnt;
    private bool flg;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cnt = 0;
        flg = false;
        //Transform Oneshotausio=
        //Oneshotaudio = 60f;
       
    }

    private void Update()
    {
        if (flg == true)
        {
            cnt++;
            Debug.Log(cnt);
        }
        //cntが60より多くなったら音楽を止めてオブジェクトを消す。
        if(cnt >= 30)        
        {
            audioSource.Stop();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //当たったオブジェクトがPlayerだったらaudioを再生。
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            //AudioSource.PlayClipAtPoint(sound, transform.position);
            flg = true;
        }
    }
} 