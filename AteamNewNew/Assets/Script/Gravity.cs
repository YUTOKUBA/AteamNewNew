using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Gravity : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public float speed = 20;        // 動く速さ
=======
    public float speed = 3;        // 動く速さ
>>>>>>> ZAYASU

=======
    [SerializeField] private Vector3 localGravity;
>>>>>>> ZAYASU
    private Rigidbody rb;
    public float speed = 3;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;          //最初にrigidBodyの重力を使わなくする
    }

    private void FixedUpdate()
    {
        SetLocalGravity();              //重力をAddForceでかけるメソッドを呼ぶ
    }

    private void SetLocalGravity()
    {
        rb.AddForce(localGravity * speed, ForceMode.Acceleration);      // 力を加える
    }
}