using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jama: MonoBehaviour
{
    void restart()
    {
        gameObject.GetComponent<Rigidbody>().Resume(gameObject);
    }

    //ボールの色を帰る関数
    void ColorChange()
    {
         GetComponent<Renderer>().material.color = Color.red;
        Invoke("ColorWhite",1.5f);
    }

    //ボールの色を白色にする
    void ColorWhite()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"jama"ならば
        if (collision.gameObject.tag == "jama")
        {
            gameObject.GetComponent<Rigidbody>().Pause(gameObject);

            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);

            //ボールの色を変える
            ColorChange();

            //動きを再開
            Invoke("restart", 1.5f);
        }

    }
}
