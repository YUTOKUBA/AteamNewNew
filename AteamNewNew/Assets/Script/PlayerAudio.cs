using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    //public AudioClip sound;
    private bool flg;
    private int con;

    private void Start()
    {
        flg = false;
        con = 0;
    }
    private void Update()
    {
        if (flg == false)
        {
            if (con >= 60)
            {
                con++;
                Debug.Log(con);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            flg = true;
        }
    }
}