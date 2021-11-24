using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atarihantei : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

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
                        Destroy(gameObject);
                    }
                }
                else if (this.transform.position.z < target.position.z)
                {
                    if ((target.position.z - this.transform.position.z) < 0.2)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        else if (this.transform.position.x < target.position.x)
        {

            if ((target.position.x - this.transform.position.x) < 0.2)
            {
                if (this.transform.position.z > target.position.z)
                {
                    if ((this.transform.position.z - target.position.z) < 0.2)
                    {
                                Destroy(gameObject);                                                                          
                    }
                }
            }
        }
        else if (this.transform.position.z < target.position.z)
        {
            if ((target.position.z - this.transform.position.z) < 0.2)
            {
                        Destroy(gameObject);
            }
        }
    }
}