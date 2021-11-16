using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    AudioSource audioSource;
   

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("cube");
        Debug.Log("コルーチンを実施中です");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")//ボールが当たるとコルーチンを呼び出し、音を鳴らす。
        {
            audioSource.Play();
            StartCoroutine("cube");
            Debug.Log("音を鳴らします");
            
        }
      
    }

    private IEnumerator cube()
    {
      for (int i = 0; i < 60; i++)
      {
            yield return null;
      }
        audioSource.Stop();
        Debug.Log("音を止めています。");
    }
}
