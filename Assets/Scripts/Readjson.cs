using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public struct ChartData //全体の設定
    {
        public string name;
        public int maxBlock;
        public float BPM;
        public int offset;
        public List<Note> notes;
    }

    [System.Serializable]
    public struct Note //ノーツの設定
    {
        public int LPB;
        public int num;
        public int block;
        public int type;
    }
public class Readjson : MonoBehaviour
{
    private string filePath;
    public ChartData obj;

    private void Awake()//読み込むために始めに処理
    {
        filePath = "PlayMusic/" + MusicSelect.SelectMusic.ToString() + "/" + MusicSelect.SelectMusic.ToString();
        var json = Resources.Load<TextAsset>(filePath).text;
        obj = JsonUtility.FromJson<ChartData>(json);
        
    }
}