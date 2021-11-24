using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearBGM : MonoBehaviour
{
    int score;

    GameObject Ball;
    coinkesu var;


    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ball = GameObject.Find("Ball");
        var = Ball.GetComponent<coinkesu>();
        if (var.coin==12)
        {
            audioSource.Pause();
        }
    }
}
