using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodaiYoko : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.01f;
    public float move2 = 0f;

    void Update()
    {
        Vector3 pos = new Vector3(move, 0, move2);
        transform.Translate(pos);
        counter++;

        if (counter == 250)
        {
            move *= -1;
        }
        if(counter == 500)
        {
            move = 0;
            move2 += 0.01f;
        }
        if(counter == 750)
        {
            move2 *= -1;
        }
        if(counter == 1000)
        {
            move += 0.01f;
            move2 = 0;
            counter = 0;
        }
    }
}
