using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallTate4 : MonoBehaviour
{
    public int counter = 0;
    public float move = -0.01f;

    void Update()
    {
        Vector3 pos = new Vector3(0, 0, move);
        transform.Translate(pos);
        counter++;

        if (counter == 50)
        {
            move *= -1;
        }
        if (counter == 200)
        {
            move *= -1;
        }
        if (counter == 250)
        {
            move *= -1;
        }
        if (counter == 300)
        {
            move *= -1;
        }
        if (counter == 450)
        {
            move *= -1;
        }
        if (counter == 500)
        {
            counter = 0;
            move *= -1;
        }
    }
}
