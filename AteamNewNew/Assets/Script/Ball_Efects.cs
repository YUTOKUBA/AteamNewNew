using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Efects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footSmoke;   //砂埃のエフェクト
    [SerializeField]
    private ParticleSystem shock_wave;  //壁に当たった際のエフェクト
    [SerializeField]
    private ParticleSystem sparkle;     //コインを取得した際のエフェクト

    [SerializeField]
    private AudioSource Rolling_Audio;
    [SerializeField]
    private AudioSource fall_Audio;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision col)
    {
        //砂埃エフェクト
        if (col.gameObject.tag == "Floor")
        {
            // 速度が0.1以上なら
            if (rb.velocity.magnitude > 0.5f)
            {
                // 再生
                if (!footSmoke.isEmitting)
                {
                    Rolling_Audio.Play();
                    footSmoke.Play();
                }
            }
            else
            {
                // 停止
                if (footSmoke.isEmitting)
                {
                    Rolling_Audio.Stop();
                    footSmoke.Stop();
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {   
        //壁に当たったエフェクト
        if (other.gameObject.tag == "Wall")
        { 
            shock_wave.transform.position = this.transform.position;
            shock_wave.Play();
        }
        //コインのエフェクト
        if (other.gameObject.tag == "cube")
        {
            sparkle.transform.position = this.transform.position;
            sparkle.Play();
        }

        if (other.gameObject.tag == "Floor")
        {
            fall_Audio.Play();
        }
    }
}
