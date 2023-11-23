using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public struct ChartData //�S�̂̐ݒ�
    {
        public string name;
        public int maxBlock;
        public float BPM;
        public int offset;
        public List<Note> notes;
    }

    [System.Serializable]
    public struct Note //�m�[�c�̐ݒ�
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

    private void Awake()//�ǂݍ��ނ��߂Ɏn�߂ɏ���
    {
        filePath = "PlayMusic/" + MusicSelect.SelectMusic.ToString() + "/" + MusicSelect.SelectMusic.ToString();
        var json = Resources.Load<TextAsset>(filePath).text;
        obj = JsonUtility.FromJson<ChartData>(json);
        
    }
}