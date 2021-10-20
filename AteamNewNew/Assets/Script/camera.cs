using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject ball;   //追いかけるターゲット
    private Vector3 offset;   //カメラとターゲットの座標の差分

    void Start()
    {
        offset = transform.position - ball.transform.position;    //カメラとターゲットの差分をメモする
    }

    void Update()
    {
        if (Mathf.Abs(ball.transform.position.x) >= 0.15f || Mathf.Abs(ball.transform.position.z) >= 0.15f)
        //if(transform.position - ball.transform.position = 0.15f)
        {
            transform.position = ball.transform.position + offset; //ターゲットの座標に、差分を追加した座標にカメラを移動させ
        }
    }
}
