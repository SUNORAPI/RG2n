using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Judge : MonoBehaviour
{
    [SerializeField] public GameObject hiscore; 
    public static int PGREAT=0;
    public static int GREAT=0;
    public static int POOR=0;
    public static int COMBO=0;
    public static int SCORE=0;
    public static int LIFE=1000;
    public static int game = 0;
    float timejudge = 0.0f;
    public int a = 2;
    public float timejudgeNote = 0.0f;
    float time = 0.0f;
    int judge = 0;
    public int keynum;
    KeyCode[] key = 
        //new KeyCode[9] {KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8};
        new KeyCode[9] {KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9, KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6, KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3};

    // Update is called once per frame
    private void Start()
    {
        game = 0;
        //Debug.Log("judge"+timejudgeNote);
    }
    void Update()
    {
        //Debug.Log(keynum);
        Text hiscoreT = hiscore.GetComponent<Text>();
        time += Time.deltaTime;
        if (Input.GetKeyDown(key[keynum]))
        {
            timejudge =timejudgeNote - time;
            NotesJudge();
            //Debug.Log("judge"+judge);
        }

        if (timejudgeNote - time < -0.5001)
        {
            /* //DemoPlayMode
            var dice = Random.Range(0, 6);
            if (dice ==0)
            {
                judge += 0;
                POOR++;
                LIFE -= 10;
                COMBO = 0;
                hiscoreT.text = "miss";
                Destroy();
               
            }
            if((dice ==1)||(dice == 2))
            {
                judge += 1;
                GREAT++;
                COMBO++;
                Destroy();
                hiscoreT.text = "good";
                
            }
            if((dice ==3)||(dice ==4)||(dice == 5))
            {
                judge += 2;
                PGREAT++;
                LIFE += 1;
                COMBO++;
                hiscoreT.text = "great";
                Destroy();
            }*/
            
            judge += 0;
            POOR++;
            LIFE -= 10;
            COMBO = 0;
            hiscoreT.text = "miss";
            Destroy();
        }

        SCORE = 30*PGREAT + 15*GREAT + 0*POOR;
        //Debug.Log("LIFE" + LIFE);
        if(LIFE <= 0)
        {
            game = 1;//gameover
            Debug.Log("gameover//////////////////////////////");
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
            PGREAT++;
            LIFE+=5;
            COMBO++;
            Destroy();
        }

        if (((timejudge <= 0.3334f / a) && (timejudge > 0.1667f / a)) || ((timejudge < -0.1667f / a) && (timejudge >= -0.3334f / a)))
        {
            judge += 1;
            GREAT++;
            LIFE +=1;
            COMBO++;
            Destroy();
        }

        if (((timejudge <= 0.5001f / a) && (timejudge > 0.3334f / a)) || ((timejudge < -0.3334f / a) && (timejudge >= -0.5001f / a)))
        {
            judge += 0;
            POOR++;
            LIFE-=10;
            COMBO = 0;
            Destroy();
            /*judge += 2;
            PGREAT++;
            LIFE += 1;
            COMBO++;
            Destroy();*/
        }
    }
}
