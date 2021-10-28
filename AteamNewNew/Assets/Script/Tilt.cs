﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tilt : MonoBehaviour
{
    public float speed = 82f;
    public float back_speed = 125f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        float back_step = back_speed * Time.deltaTime;

        if (Input.GetAxisRaw("L_Stick_Y") != 0 || Input.GetAxisRaw("L_Stick_X") != 0)
        {
            if (Input.GetAxisRaw("L_Stick_Y") < 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(30f, 0, 0), step);
            }
            if (Input.GetAxisRaw("L_Stick_Y") > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-30f, 0, 0), step);
            }

            if (Input.GetAxisRaw("L_Stick_X") < 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30f), step);
            }
            if (Input.GetAxisRaw("L_Stick_X") > 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30f), step);
            }

        }
        else if(Input.GetAxisRaw("L_Stick_Y") == 0 && Input.GetAxisRaw("L_Stick_X") == 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), back_step);
        }

        Debug.Log(1 / Time.deltaTime);
    }
}