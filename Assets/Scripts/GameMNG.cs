using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMNG : MonoBehaviour
{
    [SerializeField] public GameObject score;
    [SerializeField] public GameObject life;
    [SerializeField] public GameObject combo;
    AudioSource audiosc;
    public static int AudioPlaynow;
    private void Start()
    {
        audiosc = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Text scoreT = score.GetComponent<Text>();
        //Text hiscoreT = hiscore.GetComponent<Text>();
        Text lifeT = life.GetComponent<Text>();
        Text comboT = combo.GetComponent<Text>();
        scoreT.text = Judge.SCORE.ToString();
        lifeT.text = Judge.LIFE.ToString();
        comboT.text = Judge.COMBO.ToString();
        if(Judge.game == 1)
        {
            audiosc.Stop();
            AudioPlaynow = 0;
            Debug.Log("game == 1//////////////////////////////");
            Initiate.Fade("Result", Color.black, 1.0f);
        }
        if ((!audiosc.isPlaying)&&(Judge.game == 0)&&(AudioPlaynow == 1))
        {
            Judge.game = 2;
            AudioPlaynow = 0;
            //Debug.Log("game == 2//////////////////////////////");
            Initiate.Fade("Result",Color.black,1.0f);
        }
    }
}
