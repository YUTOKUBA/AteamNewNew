using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    void Update()
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();

        //Debug.Log(rb.velocity.magnitude);
    }

    void FixedUpdate()
    {

        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0f, -20f, 0f);


        if (rb.velocity.magnitude < 10f)
        {
            rb.AddForce(force);
        }

    }
}
