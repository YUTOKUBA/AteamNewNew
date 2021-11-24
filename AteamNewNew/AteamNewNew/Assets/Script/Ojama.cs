using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//一時停止時の速度を保管するクラス
public class Ojama : MonoBehaviour
{
    //一時停止時の速度
    private Vector3 _angularVelocity;
    private Vector3 _velocity;

    public Vector3 AngularVelocity
    {
        get { return _angularVelocity; }
    }
    public Vector3 Velocity
    {
        get { return _velocity; }
    }

    /// <summary>
    /// Rigidbody2Dを入力して速度を設定する
    /// </summary>
    public void Set(Rigidbody rigidbody)
    {
        _angularVelocity = rigidbody.angularVelocity;
        _velocity = rigidbody.velocity;
    }

}

/// <summary>
/// Rigidbody 型の拡張メソッドを管理するクラス
/// </summary>
public static class RigidbodyExtension
{

    //一時停止時の速度
    private static Vector3 _angularVelocity;
    private static Vector3 _velocity;

    /// <summary>
    /// 一時停止
    /// </summary>
    public static void Pause(this Rigidbody rigidbody, GameObject gameObject)
    {
        gameObject.AddComponent<Ojama>().Set(rigidbody);
        rigidbody.isKinematic = true;
    }

    /// <summary>
    /// 再開
    /// </summary>
    public static void Resume(this Rigidbody rigidbody, GameObject gameObject)
    {
        if (gameObject.GetComponent<Ojama>() == null)
        {
            return;
        }

        rigidbody.velocity = gameObject.GetComponent<Ojama>().Velocity;
        rigidbody.angularVelocity = gameObject.GetComponent<Ojama>().AngularVelocity;
        rigidbody.isKinematic = false;

        GameObject.Destroy(gameObject.GetComponent<Ojama>());
    }

}