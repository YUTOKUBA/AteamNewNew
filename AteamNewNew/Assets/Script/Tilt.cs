using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilt : MonoBehaviour
{
    Transform target;
    float speed = 90f;
    float back_speed = 60f;
    bool keyon = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cube").transform;
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        float back_step = back_speed * Time.deltaTime;
        if (Input.GetAxisRaw("L_Stick_Y") == -1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(30f, 0, 0), step);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-30f, 0, 0), back_step);
        }
        if (Input.GetAxisRaw("L_Stick_Y") == 1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-30f, 0, 0), step);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(30f, 0, 0), back_step);
        }
        if (Input.GetAxisRaw("L_Stick_X") == -1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30f), step);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30), back_step);
        }
        if (Input.GetAxisRaw("L_Stick_X") == 1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30f), step);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30f), back_step);
        }
    }
}