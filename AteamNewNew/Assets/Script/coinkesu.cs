using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinkesu : MonoBehaviour
{
    public int coin = 0;
    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collision.gameObject.tag == "cube")
        {
            coin++;
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }
    }
}
