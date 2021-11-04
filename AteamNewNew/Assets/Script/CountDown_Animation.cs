using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown_Animation : MonoBehaviour
{
    public void StartCountDown()
    {
        //カウントダウン開始時に行いたい処理
        Time.timeScale = 0f;
    }
    public void CompletedCountDown()
    {
        //カウントダウン終了後に行いたい処理
        Time.timeScale = 1.0f;
    }
}
