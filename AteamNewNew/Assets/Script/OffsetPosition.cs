using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPosition : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public int coin = 0;
    public bool count_flg;

    void Update()
    {


        if (this.transform.position.x > target.position.x)
        {
            if ((this.transform.position.x - target.position.x) < 0.2)
            {
                
                if (this.transform.position.z > target.position.z)
                {
                    if ((this.transform.position.z - target.position.z) < 0.2)
                    {
                      
                        if (this.transform.position.y > target.position.y)
                        {
                            if ((this.transform.position.y - target.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                        else if(this.transform.position.y < target.position.y)
                        {
                            if ((target.position.y - this.transform.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                    }
                }
                else if(this.transform.position.z < target.position.z)
                {
                    if ((target.position.z - this.transform.position.z) < 0.2)
                    {
                        if (this.transform.position.y > target.position.y)
                        {
                            if ((this.transform.position.y - target.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                        else if(this.transform.position.y < target.position.y)
                        {
                            if ((target.position.y - this.transform.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                    }
                }
            }
        }
        else if(this.transform.position.x < target.position.x)
        {

            if ((target.position.x - this.transform.position.x) < 0.2)
            {
                if (this.transform.position.z > target.position.z)
                {
                    if ((this.transform.position.z - target.position.z) < 0.2)
                    {
                        if (this.transform.position.y > target.position.y)
                        {
                            if ((this.transform.position.y - target.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                        else if(this.transform.position.y < target.position.y)
                        {
                            if ((target.position.y - this.transform.position.y) < 0.2)
                            {
                                count_flg = true;
                                Destroy(gameObject);
                                count_flg = false;
                            }
                        }
                    }
                }
            }
        }
        else if (this.transform.position.z < target.position.z)
        {
            if ((target.position.z - this.transform.position.z) < 0.2)
            {
                if (this.transform.position.y > target.position.y)
                {
                    if ((this.transform.position.y - target.position.y) < 0.2)
                    {
                        count_flg = true;
                        Destroy(gameObject);
                        count_flg = false;
                    }
                }
                else if(this.transform.position.y < target.position.y)
                {
                    if ((target.position.y - this.transform.position.y) < 0.2)
                    {
                        count_flg = true;
                        Destroy(gameObject);
                        count_flg = false;
                    }
                }
            }
        }
    }
}