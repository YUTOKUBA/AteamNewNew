using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilt : MonoBehaviour
{
    public float speed = 0;
    public float add_speed = 0.445f;
    public float decelerate_speed = 0.6f;
    public float max_speed = 36f;
    public float step = 0;
    public bool stop = true;
    public bool decelerate = false;
    public bool stop_0 = true;
    public bool change = false;


    void Start()
    {

    }

    void Update()
    {

        step = speed * Time.deltaTime;

        if (Input.GetAxisRaw("L_Stick_Y") != 0 || Input.GetAxisRaw("L_Stick_X") != 0)
        {
            stop = false;
            decelerate = true;
            stop_0 = false;

            if (stop == false)
            {
                if (Input.GetAxis("L_Stick_Y") < 0)
                {
                    if (change == true)
                    {
                        speed -= decelerate_speed;

                        if (speed <= 0)
                        {
                            speed = 0;

                            change = false;
                        }
                    }

                    if (change == false)
                    {
                        if (speed <= max_speed)
                        {
                            speed += add_speed;
                        }
                    }

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(30f, 0, 0), step);
                }
                if (Input.GetAxis("L_Stick_Y") > 0)
                {
                    if (change == true)
                    {
                        speed -= decelerate_speed;

                        if (speed <= 0)
                        {
                            speed = 0;

                            change = false;
                        }
                    }

                    if (change == false)
                    {
                        if (speed <= max_speed)
                        {
                            speed += add_speed;
                        }
                    }

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-30f, 0, 0), step);
                }

                if (Input.GetAxis("L_Stick_X") < 0)
                {
                    if (change == true)
                    {
                        speed -= decelerate_speed;

                        if (speed <= 0)
                        {
                            speed = 0;

                            change = false;
                        }
                    }

                    if (change == false)
                    {
                        if (speed <= max_speed)
                        {
                            speed += add_speed;
                        }
                    }

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 30f), step);
                }
                if (Input.GetAxis("L_Stick_X") > 0)
                {
                    if (change == true)
                    {
                        speed -= decelerate_speed;

                        if (speed <= 0)
                        {
                            speed = 0;

                            change = false;
                        }
                    }

                    if (change == false)
                    {
                        if (speed <= max_speed)
                        {
                            speed += add_speed;
                        }
                    }

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30f), step);
                }

            }

        }
        else if (Input.GetAxisRaw("L_Stick_Y") == 0 && Input.GetAxisRaw("L_Stick_X") == 0)
        {
            if(stop_0 == false)
            {
                stop_0 = true;
            }

            if (stop_0 == true)
            {
                if (speed <= max_speed)
                {
                    speed += add_speed;
                }

                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), step);

                if (this.transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    stop = false;

                    speed = 0;
                }
            }
        }
    }
}
