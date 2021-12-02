using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void kaijo()
    {
        this.gameObject.transform.parent = null;    //親子関係を解除
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")     //もしタグがjamaのオブジェクトに衝突したら
        {
            transform.parent = GameObject.Find("DODAI").transform;  //DODAIの子オブジェクトになる
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jama")     //もしタグがjamaのオブジェクトに衝突したら
        {
            transform.parent = GameObject.Find("DODAI").transform;  //DODAIの子オブジェクトになる
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")     //もしタグがjamaのオブジェクトに衝突したら
        {
            kaijo();
        }
    }
}
