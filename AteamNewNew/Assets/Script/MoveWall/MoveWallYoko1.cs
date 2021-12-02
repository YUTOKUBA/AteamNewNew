using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallYoko1 : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.01f;

    void Update()
    {
        Vector3 pos = new Vector3(move, 0, 0);
        transform.Translate(pos);
        counter++;

        if (counter == 150)
        {
            counter = 0;
            move *= -1;
        }
    }
}
