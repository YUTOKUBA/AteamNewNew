using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Select : MonoBehaviour
{
    [SerializeField] private AudioSource Select_Audio;   //SE用のオーディオソース
    bool Push_Flg = false; //連続入力防止用スイッチ

    [SerializeField] private RectTransform Center;
    void Start()
    {

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
                Center.transform.Rotate(new Vector3(0,+90,0));
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
            SceneManager.LoadSceneAsync("Game");
        }
    }
}
