using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Efects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem footSmoke;
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
}
