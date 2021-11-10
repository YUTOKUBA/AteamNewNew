using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Efects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footSmoke;
    [SerializeField]
    private ParticleSystem shock_wave;
    [SerializeField]
    private ParticleSystem sparkle;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            // 速度が0.1以上なら
            if (rb.velocity.magnitude > 0.5f)
            {
                // 再生
                if (!footSmoke.isEmitting)
                {
                    footSmoke.Play();
                }
            }
            else
            {
                // 停止
                if (footSmoke.isEmitting)
                {
                    footSmoke.Stop();
                }
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        { 
            shock_wave.transform.position = this.transform.position;
            shock_wave.Play();
        }
        if (other.gameObject.tag == "cube")
        {
            sparkle.transform.position = this.transform.position;
            sparkle.Play();
        }
    }
}
