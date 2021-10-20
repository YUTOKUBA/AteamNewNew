//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Gravity : MonoBehaviour
//{
//    [SerializeField] private Vector3 localGravity;
//    private Rigidbody rBody;

//    // Use this for initialization
//    private void Start()
//    {
//        rBody = this.GetComponent<Rigidbody>();
//        rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
//    }

//    private void FixedUpdate()
//    {
//        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。
//    }

//    private void SetLocalGravity()
//    {
//        rBody.AddForce(localGravity * a, ForceMode.Acceleration);
//    }
//}


using System.Collections.Generic;
using UnityEngine;

public class Gravityy : MonoBehaviour
{
	// 加速度　速度　位置の変数ベクトルを定義
	Vector3 acceleration;
	Vector3 velocity;
	Vector3 position;

	//　微小時間を定義
	const float dt = 1f / 60f;

	// 初期化
	void Start()
	{
		//オブジェクトの位置を変数ベクトルpositionに持ってくる
		position = transform.position;
	}

	// スクリプトtestで使用する関数AddForceを定義する
	public void AddForce(Vector3 force)
	{
		acceleration += force;
	}

	// 更新
	void FixedUpdate()
	{
		//加速度から速度と位置を計算する
		velocity += acceleration * dt;
		position += velocity * dt;

		// position.y　がオブジェクトの半径以下になったら速度を反転させる
		if (position.y < 0.50f)
		{
			velocity = -velocity;
			Debug.Log("反転しました");
		}

		// オブジェクトの位置を更新する
		transform.position = position;

		//加速度は位置の更新が終わったらゼロクリアしておくこと
		acceleration = Vector3.zero;
	}
}