using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatOBJ : MonoBehaviour
{
    public GameObject obj;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaa");  
        if(collision.gameObject.tag == "Player") 
        Instantiate(obj, transform);
    }
}
