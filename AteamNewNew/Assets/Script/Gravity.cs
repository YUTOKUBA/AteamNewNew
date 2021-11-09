using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //HitCheck();

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
    }
}
