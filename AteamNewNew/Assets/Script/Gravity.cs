using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float speed = 20;        // 動く速さ

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();         // Rigidbody を取得
    }

    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);            // カーソルキーの入力に合わせて移動方向を設定

        rb.AddForce(movement * speed);          //Rigidbodyに力を加える
    }
}