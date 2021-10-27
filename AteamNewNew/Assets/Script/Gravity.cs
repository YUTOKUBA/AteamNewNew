using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Gravity : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
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