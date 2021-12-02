using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4yuka : MonoBehaviour
{
    void kaijo()
    {
        this.gameObject.transform.parent = null;    //親子関係を解除
        transform.parent = GameObject.Find("dodai").transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jama")     //もしタグがjamaのオブジェクトに衝突したら
        {
            transform.parent = GameObject.Find("DODAI").transform;  //DODAIの子オブジェクトになる
            Invoke("kaijo", 1.5f);      //1.5f後に解除
        }
    }
}
