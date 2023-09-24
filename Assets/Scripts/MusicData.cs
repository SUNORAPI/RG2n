using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicData
{
    public Music musicName;
    public string Composer;
    public Sprite MusicIMG;
    public MusicData(Music _name,string _Cname, Sprite _MIMG)
    {
        musicName = _name;
        Composer = _Cname;
        MusicIMG = _MIMG;
    }

}
