using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodaitate : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.002f;
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
            Vector3 pos = new Vector3(0, 0, move);
            transform.Translate(pos);
            counter++;

            if (counter == 50)
            {
                counter = 0;
                move *= -1;
            }
        }
    }
}
