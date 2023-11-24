using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class JudgeData
{
    public int DestJ ;
    public float TimeJ ;
    public GameObject NoteObj;
    public int JudgeY;
    public JudgeData(int _NDest, float _NTime, GameObject _NobJ,ref int _JyetQ)
    {
        DestJ = _NDest;
        TimeJ = _NTime;
        NoteObj = _NobJ;
        JudgeY = _JyetQ;
    }
}
public class Judger : MonoBehaviour
{
    public static List<JudgeData> NoteJ = new List<JudgeData>();
    public static string[] T = new string[5] { "PERFECT", "JUST", "GOOD", "BAD", "MISS" };
    public static int PERFECT = 0;
    public static int JUST= 0;
    public static int GOOD = 0;
    public static int BAD = 0;
    public static int MISS = 0;
    public static int COMBO = 0;
    public static int SCORE = 0;
    public static int LIFE = 1000;
    public static int game = 0;
    public static int keys = 0;
    public int JudgeResult;
    private float _time = 0;
    [SerializeField] public GameObject JudgeResT;
    [SerializeField] public GameObject ScoreT;
    [SerializeField] public GameObject ComboT;
    [SerializeField] public GameObject LifeT;
    KeyCode[] key = new KeyCode[9];
    KeyCode[] key1 = new KeyCode[9] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
    KeyCode[] key2 = new KeyCode[9] { KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3 };
    // Start is called before the first frame update
    void Start()
    {
        game = 0;
        if(keys == 0)
        {
            key = key1;
        }
        else if(keys == 1)
        {
            key = key2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (game != 1)
        {
            _time += Time.deltaTime;
            for (int i = 0; i < 9; i++)
            {
                var nL = NoteJ.Where(note => note.DestJ == i).Where(note => note.JudgeY == 0).OrderBy(note => (Mathf.Abs(_time - note.TimeJ))).FirstOrDefault();
                if ((nL != null) && (Input.GetKeyDown(key[i])))
                {
                    var sum = _time - nL.TimeJ;
                    var absedsum = Mathf.Abs(sum);
                    NJudge(sum, absedsum, nL.NoteObj, ref nL.JudgeY);
                }
                if ((nL != null) && ((_time - nL.TimeJ) > 0.12f) && (nL.JudgeY == 0))//L-MISS
                {
                    MISS++;
                    COMBO = 0;
                    LIFE -= 10;
                    JudgeResult = 4;
                    nL.JudgeY = 1;
                    DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, nL.NoteObj);
                }
            }
        }
        if(LIFE <= 0)//GameOver
        {
            LIFE = 0;
            game = 1;
        }
    }
    void NJudge(float rsum,float sdv, GameObject noteD,ref int JNYQ)
    {
        if (JNYQ == 0)
        {
            if (sdv <= 0.04f)//PERFECT
            {
                PERFECT++;
                COMBO++;
                LIFE += 5;
                SCORE += 50;
                JudgeResult = 0;
                JNYQ = 1;
                DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, noteD);
            }
            else if (sdv <= 0.06f)//JUST
            {
                JUST++;
                COMBO++;
                LIFE += 3;
                SCORE += 30;
                JudgeResult = 1;
                JNYQ = 1;
                DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, noteD);
            }
            else if (sdv <= 0.08f)//GOOD
            {
                GOOD++;
                COMBO++;
                SCORE += 10;
                JudgeResult = 2;
                JNYQ = 1;
                DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, noteD);
            }
            else if (sdv <= 0.10f)//BAD
            {
                BAD++;
                COMBO = 0;
                JudgeResult = 3;
                JNYQ = 1;
                DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, noteD);
            }
            else if (sdv < 0.12f)//MISS
            {
                MISS++;
                COMBO = 0;
                LIFE -= 10;
                JudgeResult = 4;
                JNYQ = 1;
                DisplayJudge(COMBO, LIFE, SCORE, JudgeResult, noteD);
            }

        }
    }

    void DisplayJudge(int ComboTxt, int LifeTxt, int ScoreTxt, int JudRT, GameObject ND)
    {
        var JRT = JudgeResT.GetComponent<Text>();
        var ST = ScoreT.GetComponent<Text>();
        var CT = ComboT.GetComponent<Text>();
        var LT = LifeT.GetComponent<Text>();
        CT.text = ComboTxt.ToString();
        LT.text = LifeTxt.ToString();
        ST.text = ScoreTxt.ToString();
        JRT.text = T[JudRT];
        ND.SetActive(false);
    }
}
