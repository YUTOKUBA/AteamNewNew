using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private AudioSource SE_Audio;   //SE用のオーディオソース
    [SerializeField] private AudioSource BGM_Audio;   //SE用のオーディオソース
    public double FadeOutSeconds = 1.0;
    bool IsFadeOut = false;
    double FadeDeltaTime = 0;
    void Start()
    {
        Time.timeScale = 1f;
        BGM_Audio.volume = 0.5f;
        FadeOutSeconds = 1.0;
        FadeDeltaTime = 0;
        IsFadeOut = false;
    }

    void Update()
    {
         if (Input.anyKeyDown)
        {
            SE_Audio.Play();
            IsFadeOut = true;
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
            SceneManager.LoadScene("Stage_Select");
        }
    }
}
