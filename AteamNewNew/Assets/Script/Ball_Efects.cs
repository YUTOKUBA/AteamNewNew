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
    [SerializeField]
    private AudioSource jama_Audio;
    [SerializeField]
    private AudioSource otasuke_Audio;

    bool fall_oneShot = true;

    private Rigidbody rb;

    GameObject gamemanager;    //flgが入っているオブジェクト
    GameManager var;       //空箱
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        gamemanager = GameObject.Find("GameManager");
        var = gamemanager.GetComponent<GameManager>();

        if (var.Clear_flg == true)
        {
            Rolling_Audio.Stop();
        }
    }

    void OnCollisionStay(Collision col)
    {
        //砂埃エフェクト
        if (col.gameObject.tag == "Floor")
        {
            // 速度が0.5以上なら
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
        //地面に衝突した時のSE
        if (other.gameObject.tag == "Floor" && fall_oneShot == true)
        {
            fall_Audio.Play();
            fall_oneShot = false;
        }

        if (other.gameObject.tag == "jama")
        {
            jama_Audio.Play();
        }
        if (other.gameObject.tag == "otasuke")
        {
            otasuke_Audio.Play();
        }
    }
}
