using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        transform.parent = GameObject.Find("DODAI").transform;
    }
}
