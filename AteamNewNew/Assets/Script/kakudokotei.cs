using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakudokotei : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(45, 45, 45);
    }
}
