using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinkesu : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collision.gameObject.tag == "cube")
        {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }
    }
}
