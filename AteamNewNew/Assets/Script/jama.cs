using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jama: MonoBehaviour
{
    void restart()
    {
        gameObject.GetComponent<Rigidbody>().Resume(gameObject);
    }
        
    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"jama"ならば
        if (collision.gameObject.tag == "jama")
        {
            gameObject.GetComponent<Rigidbody>().Pause(gameObject);
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            //動きを再開
            Invoke("restart", 1.5f);  
        }
        
    }
}
