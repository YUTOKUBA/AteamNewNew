using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown_Animation : MonoBehaviour
{
    [SerializeField] private AudioSource count_Audio;
    [SerializeField] private AudioSource whistle_Audio;

    GameObject gamemanager;    //スコアが入っているオブジェクト
    GameManager var;       //空箱

    public void Ready()
    {
        //カウントダウン開始時に行いたい処理
        Time.timeScale = 0f;
    }
    public void StartCountDown()
    {
        count_Audio.Play();
    }

    public void whistle()
    {
        count_Audio.Stop();
        whistle_Audio.Play();
    }

    public void CompletedCountDown()
    {
        gamemanager = GameObject.Find("GameManager");
        var = gamemanager.GetComponent<GameManager>();

        //カウントダウン終了後に行いたい処理
        Time.timeScale = 1.0f;
        var.Start_flg = false;
        var.BGM_flg = true;
    }
}
