using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallTate : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.01f;

    void Update()
    {
        Vector3 pos = new Vector3(0, 0, move);
        transform.Translate(pos);
        counter++;

        if (counter == 250)
        {
            counter = 0;
            move *= -1;
        }
    }
}
