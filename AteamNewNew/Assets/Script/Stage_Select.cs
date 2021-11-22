using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Select : MonoBehaviour
{
    [SerializeField] private AudioSource Select_Audio;   //SE用のオーディオソース
    bool Push_Flg = false; //連続入力防止用スイッチ

    [SerializeField] private AudioSource BGM_Audio;   //SE用のオーディオソース

    [SerializeField] private RectTransform Center;

    public bool IsFade;
    public double FadeOutSeconds = 1.0;
    bool IsFadeOut = false;
    double FadeDeltaTime = 0;

    bool IsRotate = false;
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
            if (Push_Flg == false)
            {
                Push_Flg = true;
                IsRotate = true;
            }
        }
        else if (lsh == -1)
        {
            if (Push_Flg == false)
            {
                Push_Flg = true;
                Center.transform.Rotate(new Vector3(0, -90, 0));
            }
        }
        else
        {
            Push_Flg = false;
        }
        if (Input.GetButtonDown("A"))
        {
            Select_Audio.Play();
            IsFadeOut = true;
        }

        if (IsRotate)
        {
            Center.transform.Rotate(new Vector3(0, 10.0f * Time.deltaTime, 0));
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
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
