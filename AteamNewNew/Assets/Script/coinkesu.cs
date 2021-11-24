using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinkesu : MonoBehaviour
{
    public int coin = 0;
    //otasuke = 
   
    void syukusyou()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collision.gameObject.tag == "cube")
        {
            coin++;
            // 衝突した相手オブジェクトを削除する
            Debug.Log("反応している。");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "otasuke")
        {

            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            transform.localScale =new Vector3(0.4f, 0.4f, 0.4f);
            Invoke(nameof(syukusyou), 7.5f);
        }
    }
}
