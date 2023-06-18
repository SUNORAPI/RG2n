using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //float Audiotime = 0.0f;
    AudioSource Timeoffset;
    // Start is called before the first frame update
    void Start()
    {
        Timeoffset = gameObject.GetComponent<AudioSource>();
        StartCoroutine(AudioCoroutine());
    }

    IEnumerator AudioCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        Timeoffset.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
