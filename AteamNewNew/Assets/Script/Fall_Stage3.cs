using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Stage3: MonoBehaviour
{
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 tmp = GameObject.Find("Ball").transform.position;
        if (this.transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            GameObject.Find("Ball").transform.position = new Vector3(0, 0.8f, -0.4f);
        }
    }
}


