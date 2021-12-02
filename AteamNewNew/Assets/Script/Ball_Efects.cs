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
    private AudioSource Landing_Audio;
    [SerializeField]
    private AudioSource Collision_Audio;
    [SerializeField]
    private AudioSource jama_Audio;
    [SerializeField]
    private AudioSource otasuke_Audio;
    [SerializeField]
    private AudioSource Fall_Audio;

    bool Fall_oneShot = false;
    bool Landing_oneShot = true;

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

        //落下したら
        if (this.transform.position.y < -1.5 && this.transform.position.y > -9)
        {
            if (Fall_oneShot == false)
            {
                Fall_Audio.Play();
                Fall_oneShot = true;
                Rolling_Audio.Stop();
                footSmoke.Stop();
            }
        }
        if (this.transform.position.y <= -9)
        {
            Fall_oneShot = false;
            Landing_oneShot = true;
        }

        //クリアしたら
        if (var.Clear_flg == true)
        {
            Rolling_Audio.Stop();
            Fall_Audio.Stop();
        }

        //ポーズ画面中
        if (var.pause_flg != false)
        {
            Rolling_Audio.Pause();
            Fall_Audio.Pause();
        }
        else
        {
            Rolling_Audio.UnPause();
            Fall_Audio.UnPause();
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
            Collision_Audio.Play();
        }
        //コインのエフェクト
        if (other.gameObject.tag == "cube")
        {
            sparkle.transform.position = this.transform.position;
            sparkle.Play();
        }
        //地面に衝突した時のSE
        if (other.gameObject.tag == "Floor" && Landing_oneShot == true)
        {
            Landing_Audio.Play();
            Landing_oneShot = false;
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
