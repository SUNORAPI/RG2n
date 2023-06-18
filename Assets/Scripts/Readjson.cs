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
    private string _dataPath;
    public ChartData obj;

    private void Awake()//読み込むために始めに処理
    {
        var json = Resources.Load<TextAsset>("chart").text;

        //jsonからオブジェクトにデータを入れる
        obj = JsonUtility.FromJson<ChartData>(json);
        Debug.Log(obj.notes[0].LPB);
        Debug.Log(json);

    }
}