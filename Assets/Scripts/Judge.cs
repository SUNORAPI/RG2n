using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Judge : MonoBehaviour
{
    float timejudge = 0.0f;
    public int a = 2;
    public float timejudgeNote = 0.0f;
    float time = 0.0f;
    int judge = 0;
    public int keynum;
    KeyCode[] key = new KeyCode[9] {KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8};

    // Update is called once per frame
    void Update()
    {
        Debug.Log(keynum);
        time += Time.deltaTime;
        if (Input.GetKeyDown(key[keynum]))
        {
            timejudge =timejudgeNote - time;
            NotesJudge();
            Debug.Log(judge);
        }

        if (timejudgeNote - time < -0.5001)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }

    void NotesJudge()
    {
        if (((timejudge >= -0.1667f / a) && (timejudge <= 0.1667f / a)))
        {
            judge += 2;
            Destroy();
        }

        if (((timejudge <= 0.3334f / a) && (timejudge > 0.1667f / a)) || ((timejudge < -0.1667f / a) && (timejudge >= -0.3334f / a)))
        {
            judge += 1;
            Destroy();
        }

        if (((timejudge <= 0.5001f / a) && (timejudge > 0.3334f / a)) || ((timejudge < -0.3334f / a) && (timejudge >= -0.5001f / a)))
        {
            judge += 0;
            Destroy();
        }
    }
}
