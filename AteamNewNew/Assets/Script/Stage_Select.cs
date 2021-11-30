using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Select : MonoBehaviour
{
    [SerializeField] private AudioClip cursor_sound;    //カーソルのSE
    [SerializeField] private AudioClip select_sound;    //セレクト時のSE
    [SerializeField] private AudioSource Select_Audio;   //SE用のオーディオソース
    bool Push_Flg = false; //連続入力防止用スイッチ
    bool Stop_flg = false;

    [SerializeField] private AudioSource BGM_Audio;   //SE用のオーディオソース

    [SerializeField] private Transform Center;

    public bool IsFade;
    public double FadeOutSeconds = 1.0;
    bool IsFadeOut = false;
    double FadeDeltaTime = 0;

    //回転中かどうか
    bool coroutineBool = false;

    int Stage_num = 0;


    void Start()
    {
        FadeDeltaTime = 0;
    }

    void Update()
    {
        float lsh = Input.GetAxis("L_stick_h");
        float lsv = Input.GetAxis("L_stick_v");
        if (lsh == 1)
        {
            if (Push_Flg == false && Stop_flg == false)
            {
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    StartCoroutine("RightMove");

                    Push_Flg = true;
                    Stage_num++;
                    if (Stage_num >= 4)
                    {
                        Stage_num = 0;
                    }
                    Select_Audio.PlayOneShot(cursor_sound);
                }
            }
        }
        else if (lsh == -1)
        {
            if (Push_Flg == false && Stop_flg == false)
            {
                if (!coroutineBool)
                {
                    coroutineBool = true;
                    StartCoroutine("LeftMove");

                    Push_Flg = true;
                    Stage_num--;
                    if (Stage_num <= -1)
                    {
                        Stage_num = 3;
                    }
                    Select_Audio.PlayOneShot(cursor_sound);
                }
            }
        }
        else
        {
            Push_Flg = false;
        }
        if (Input.GetButtonDown("A"))
        {
            Select_Audio.PlayOneShot(select_sound);
            IsFadeOut = true;
            Stop_flg = true;
        }

        if (IsFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime == FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                IsFadeOut = false;
            }
            BGM_Audio.volume = (float)(1.0 - FadeDeltaTime / FadeOutSeconds);
        }
        if (BGM_Audio.volume == 0.0f)
        {
            switch (Stage_num) 
            {
                case 0:
                    SceneManager.LoadSceneAsync("Stage1");
                    break;
                case 1:
                    SceneManager.LoadSceneAsync("Stage2");
                    break;
                case 2:
                    SceneManager.LoadSceneAsync("Stage3");
                    break;
                case 3:
                    SceneManager.LoadSceneAsync("Stage4");
                    break;
            }

        }
    }

    //右にゆっくり回転して90°でストップ
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 90; turn+=5)
        {
            transform.Rotate(0, 5, 0);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }

    //左にゆっくり回転して90°でストップ
    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < 90; turn+=5)
        {
            transform.Rotate(0, -5, 0);
            yield return new WaitForSeconds(0.01f);
        }
        coroutineBool = false;
    }
}
