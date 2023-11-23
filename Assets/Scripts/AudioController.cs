using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource Timeoffset;
    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = "PlayMusic/" + MusicSelect.SelectMusic.ToString() + "/" + MusicSelect.SelectMusic.ToString();
        var music = Resources.Load<AudioClip>(filePath);
        Timeoffset = gameObject.GetComponent<AudioSource>();
        Timeoffset.clip = music;
        StartCoroutine(AudioCoroutine());
    }

    IEnumerator AudioCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        Timeoffset.Play();
        GameMNG.AudioPlaynow = 1;
    }
}