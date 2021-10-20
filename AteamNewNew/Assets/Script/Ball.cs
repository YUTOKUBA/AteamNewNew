//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Ball : MonoBehaviour
//{

//    void Update()
//    {
//        Rigidbody rb = this.transform.GetComponent<Rigidbody>();

//        Debug.Log(rb.velocity.magnitude);
//    }

//    void FixedUpdate()
//    {

//        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
//        Vector3 force = new Vector3(0f, -20f, 0f);


//        if (rb.velocity.magnitude < 10f)
//        {
//            rb.AddForce(force);
//        }

//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidbody : MonoBehaviour
{
	public Vector3 acceleration;    //加速度。これがないと物理シミュレーションは始まらない。

	public Vector3 velocity;    //速度。微小時間dtの間の加速度を、積分でいっぱい集めると速度になる

	public Vector3 position;    //位置は速度の時間積分

	public float mass;  //質量に相当。
	public Vector3 gravityScale;    //重力加速度

	const float dt = 1f / 60f;  //微小時間dtに相当する部分
	public void AddForce(Vector3 force)
	{
		//変更部分開始------------------------------------
		acceleration += force / mass;   //慣性質量が働く分、力をmassで割ってから加速度に入れてあげます！
										//変更部分開始------------------------------------
	}

	void FixedUpdate()
	{

		//変更部分始め----------------------------------------
		acceleration += gravityScale;   //運動方程式から、両辺m（mass)で割った結果を使います！

		velocity += acceleration * Time.fixedDeltaTime; //積分に使う微小時間を、デルタタイムに変更！
		position += velocity * Time.fixedDeltaTime; //速度を時間積分
													//変更部分終わり---------------------------------------

		//地面と接触したら、跳ね返る表現。
		//地面との衝突判定の代わりに、地面に近いところまで落ちたら速度を反転している。
		if (position.y < 0.5f)
		{
			velocity = -velocity;
		}
		transform.position = position;
		acceleration = Vector3.zero;    //加速度をリセット。加えた力の影響を最後にリセット	
	}
}

//public class ChangeGravity : MonoBehaviour
//{
//    [SerializeField] private Vector3 localGravity;
//    private Rigidbody rBody;

//    // Use this for initialization
//    private void Start()
//    {
//        rBody = this.GetComponent<Rigidbody>();
//        rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
//    }

//    private void Update()
//    {
//        var body = GameObject.Find("Sphere").GetComponent<Rigidbody>();
//        if (Input.GetKey(KeyCode.A))
//        {
//            body.WakeUp();
//        }
//    }

//    private void FixedUpdate()
//    {
//        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
//    }

//    private void SetLocalGravity()
//    {
//        rBody.AddForce(localGravity, ForceMode.Acceleration);
//    }
//}