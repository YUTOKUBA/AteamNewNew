using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAudio : MonoBehaviour
{
    AudioSource audioSource;
    float Wall;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Corou4");
        Debug.Log("コルーチンを実施中です");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Corou4");
            audioSource.Play();
        }
    }
    private IEnumerator Corou4()
    {
     for(int i = 0; i < 20; i++)
        {
            
            yield return null;
        }
        audioSource.Stop();

    }

}
