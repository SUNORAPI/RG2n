using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Music //‚±‚±‚É‹È‚ð’Ç‰Á
{
    Ring01, Ring02, Ring03,
}
public class MusicSelect : MonoBehaviour
{
    private int _select = 0;
    private int _length = Enum.GetNames(typeof(Music)).Length -1;
    public static Music SelectMusic;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _select++;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        { 
            _select--;
        }
        if (_select <= -1)
        { 
            _select = _length;
        }
        if (_select >= _length +1)
        {
            _select = 0;
        }
        SelectMusic = (Music)System.Enum.ToObject(typeof(Music), _select);
    }
}