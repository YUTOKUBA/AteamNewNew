//using System.Collections.Generic;
//using System.Collections;
//using UnityEngine;


//public class Gravity : MonoBehaviour
//{
//    [SerializeField] private Vector3 localGravity;
//    private Rigidbody rb;
//    public float speed = 3;

//    private void Start()
//    {
//        rb = this.GetComponent<Rigidbody>();
//        rb.useGravity = false;          //最初にrigidBodyの重力を使わなくする
//    }

//    private void FixedUpdate()
//    {
//        SetLocalGravity();              //重力をAddForceでかけるメソッドを呼ぶ
//    }

//    private void SetLocalGravity()
//    {
//        rb.AddForce(localGravity * speed, ForceMode.Acceleration);      // 力を加える
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

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
=======
using UnityEngine.Events;

public class Gravity : MonoBehaviour
{
    [SerializeField, Tooltip("重力値")]
    float pyhs = -1f;
    [SerializeField, Tooltip("最大加速度")] float maxVelocity = 10;
    public Vector3 velocity;

    //地面に着いたかどうか
    public bool isdodai { get { return transform.position.y <= 0; } }

    void Update()
    {
        HitCheck();

        //空中の時重力をかける
        if (velocity.y > 0 || transform.position.y != 0)
        {
            //最大加速度以下なら移動量加算
            if (Mathf.Abs(velocity.y) <= maxVelocity)
                velocity.y += pyhs;

            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
                velocity.y = 0;
            }

        }

        //移動
        transform.position += velocity * Time.deltaTime;
    }

    public void AddForce(Vector3 alpha)
    {
        velocity += alpha;
>>>>>>> ZAYASU
    }
}
