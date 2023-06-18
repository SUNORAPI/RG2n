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
    private string _dataPath;
    public ChartData obj;

    private void Awake()//�ǂݍ��ނ��߂Ɏn�߂ɏ���
    {
        var json = Resources.Load<TextAsset>("chart").text;

        //json����I�u�W�F�N�g�Ƀf�[�^������
        obj = JsonUtility.FromJson<ChartData>(json);
        Debug.Log(obj.notes[0].LPB);
        Debug.Log(json);

    }
}