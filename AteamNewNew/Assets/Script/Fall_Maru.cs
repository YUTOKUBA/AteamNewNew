﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Maru: MonoBehaviour
{
    void Update()
    {

        Vector3 tmp = GameObject.Find("Ball").transform.position;
        if (this.transform.position.y < -10)
        { 
        //    GameObject.rigidbody.velocity = Vector3.zero;
        //    GameObject.rigidbody.angularVelocity = Vector3.zero;
            GameObject.Find("Ball").transform.position = new Vector3(0, 1.5f, 2f);
        }
    }
}


