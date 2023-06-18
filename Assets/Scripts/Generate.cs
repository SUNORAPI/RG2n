using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class Generate : MonoBehaviour
{
    private int x = 0;
    private int number;
    public GameObject note;
    public GameObject[] destinations =new GameObject[9];
    public ChartData ImportData;
    public List<GameObject>NoteSet;
    public List<float> NoteJudgeTimes;

    void Start()
    {
        ImportData = gameObject.GetComponent<Readjson>().obj;
        Debug.Log(ImportData.notes.Count);
        for (int i = 0; i < ImportData.notes.Count; i++)
        {
            GameObject NotesDestination;
            float SetMoveTime = (11.0f-HiSpeed.Speed)/10; //�n�C�X�s�ݒ�
            float time = 60 / ImportData.BPM / ImportData.notes[i].LPB * ImportData.notes[i].num + ImportData.offset/48300.0f -SetMoveTime +1.0f;
            Debug.Log(time);       
            x = UnityEngine.Random.Range(0, 360);
            NotesDestination = Instantiate(note, new Vector3(12 * Mathf.Cos(x * Mathf.Deg2Rad), 0.3f, 12 * Mathf.Sin(x * Mathf.Deg2Rad)), Quaternion.identity);
            NotesDestination.GetComponent<NoteMove>().destination = destinations[ImportData.notes[i].block];
            NotesDestination.GetComponent<Judge>().keynum = ImportData.notes[i].block;
            NotesDestination.GetComponent<Judge>().timejudgeNote = 60 / ImportData.BPM / ImportData.notes[i].LPB * ImportData.notes[i].num + ImportData.offset / 48300.0f + 1.0f;
            StartCoroutine(GenerateCoroutine(ImportData.notes[i].block, time, NotesDestination, SetMoveTime));
        }
    }

    IEnumerator GenerateCoroutine(int Blocknum, float WaitSec, GameObject Mover, float SetTime)
    {
        yield return new WaitForSeconds(WaitSec);
        Mover.GetComponent<NoteMove>().Move(SetTime);
    }
}