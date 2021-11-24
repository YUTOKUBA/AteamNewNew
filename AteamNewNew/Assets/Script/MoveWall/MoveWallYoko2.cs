using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallYoko2 : MonoBehaviour
{
    public int counter = 0;
    public float move = -0.002f;

    void Update()
    {
        Vector3 pos = new Vector3(move, 0, 0);
        transform.Translate(pos);
        counter++;

        if (counter == 125)
        {
            counter = 0;
            move *= -1;
        }
    }
}
