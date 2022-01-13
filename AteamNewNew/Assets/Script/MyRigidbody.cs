using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidbody : MonoBehaviour
{
	public GameObject Cube;
	public float height = 0.6f;


	public Vector3 acceleration;    //加速度。これがないと物理シミュレーションは始まらない。

	public Vector3 velocity;    //速度。微小時間dtの間の加速度を、積分でいっぱい集めると速度になる

	public Vector3 position;    //位置は速度の時間積分

	//追加部分始め----------------------------------------
	public float mass;  //質量に相当。
	public Vector3 gravityScale;    //重力加速度
									//追加部分終わり---------------------------------------

	const float dt = 1f / 60f;  //微小時間dtに相当する部分
	public void AddForce(Vector3 force)
	{
		acceleration += force;  //加速度を増やすには、力を加えれば良い！
	}

	void FixedUpdate()
	{


		//追加部分始め---------------------------------------
		acceleration += mass * gravityScale;    //重力を発生させる。重力は質量と重力加速度の掛け算で求まる力！
												//追加部分終わり---------------------------------------

		velocity += acceleration * dt;  //加速度を時間積分
		position += velocity * dt;  //速度を時間積分

		//地面と接触したら、跳ね返る表現。
		//地面との衝突判定の代わりに、地面に近いところまで落ちたら速度を反転している。
		if (position.x <= Cube.transform.localScale.x / 2 && position.x >= Cube.transform.localScale.x / -2) {
			if (position.z <= Cube.transform.localScale.z / 2 && position.z >= Cube.transform.localScale.z / -2)
			{
				if (position.y <= Cube.transform.position.y + height)
				{
					if (velocity.y >= Mathf.Abs(0.0f))
					{
						acceleration = Vector3.zero;
						velocity.y = 0.0f;
						position.y = height;
					}
					else
					{
						Debug.Log(height);
						Reflection();
					}
				}
			}
		}
		//Rolling();
		transform.position = position;
		acceleration = Vector3.zero;    //加速度をリセット。加えた力の影響を最後にリセット	
	}

	void Reflection()
	{
		velocity.x = -(Cube.transform.rotation.z * 30f);
		velocity.y = -velocity.y;
		velocity.z = Cube.transform.rotation.x * 30f;
	}

	/*void Rolling()
    {
		height = (((position.y * position.y) / 2) + ((position.z * position.z) / 2)) * Cube.transform.rotation.z + 0.6f;
		position.y = height;
	}*/

}