using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        Debug.Log(1 / Time.deltaTime);
    }
}
