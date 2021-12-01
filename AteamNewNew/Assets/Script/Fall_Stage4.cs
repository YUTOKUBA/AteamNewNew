using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Stage4 : MonoBehaviour
{
    [SerializeField]
    private AudioSource Fall_Audio;
    bool one_sound = false;
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 tmp = GameObject.Find("Ball").transform.position;
        if (this.transform.position.y < -2)
        {
            if (one_sound == false)
            {
                Fall_Audio.Play();
                one_sound = true;
            }
        }
        if (this.transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            GameObject.Find("Ball").transform.position = new Vector3(0, 4, 0);

            one_sound = false;
        }
    }
}


