using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private Dictionary<Music, string> Musicpath = new Dictionary<Music, string>()
    {
        {Music.Ring01,"Ring01" }
    };

    //float Audiotime = 0.0f;
    AudioSource Timeoffset;
    // Start is called before the first frame update
    void Start()
    {
        var music = Resources.Load<AudioClip>("PlayMusic/" + Musicpath[MusicSelect.SelectMusic] + "/" + Musicpath[MusicSelect.SelectMusic]);
        Timeoffset = gameObject.GetComponent<AudioSource>();
        Timeoffset.clip = music;
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
