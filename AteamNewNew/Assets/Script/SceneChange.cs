using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private AudioSource SE_Audio;   //SE用のオーディオソース
    void Start()
    {
        
    }

    void Update()
    {
         if (Input.anyKeyDown)
        {
            SE_Audio.Play();
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
