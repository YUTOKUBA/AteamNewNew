using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodaiYoko : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.01f;
    public float move2 = 0f;
    public GameObject GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (GameManager.GetComponent<GameManager>().pause_flg == false &&
            GameManager.GetComponent<GameManager>().Start_flg == false &&
            GameManager.GetComponent<GameManager>().Clear_flg == false)
        {
            Vector3 pos = new Vector3(move, 0, move2);
            transform.Translate(pos);
            counter++;

            if (counter == 50)
            {
                move = -0.002f;
            }
            if (counter == 300)
            {
                move = 0;
                move2 += 0.002f;
            }
            if (counter == 450)
            {
                move2 *= -1;
            }
            if (counter == 600)
            {
                move += 0.01f;
                move2 = 0;
                counter = 0;
            }
        }
    }
}
