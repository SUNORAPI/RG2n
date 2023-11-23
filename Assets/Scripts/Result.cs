using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Result : MonoBehaviour
{
    [SerializeField] public GameObject score;
    //[SerializeField] public GameObject hiscore;
    [SerializeField] public GameObject combo;
    [SerializeField] public GameObject LIFE;
    [SerializeField] public GameObject PGREAT;
    [SerializeField] public GameObject GREAT;
    [SerializeField] public GameObject POOR;
    [SerializeField] public GameObject GAME;
    [SerializeField] public GameObject hispeed;

    [SerializeField] public RectTransform a,b,c,d,e,f,g,h,ia,j,k,l;

    [SerializeField] private Text _target;
    [SerializeField] private float _cycle = 2.0f;
    private float _time = 4.0f;

    private int PressEnterKey = 0; 

    private void Start()
    {
        PressEnterKey = 0;
        Text scoreT = score.GetComponent<Text>();
        Text comboT = combo.GetComponent<Text>();
        Text LIFET = LIFE.GetComponent<Text>();
        Text PGREATT = PGREAT.GetComponent<Text>();
        Text GREATT = GREAT.GetComponent<Text>();
        Text POORT = POOR.GetComponent<Text>();
        Text GAMET = GAME.GetComponent<Text>();
        Text hispeedT = hispeed.GetComponent<Text>();

        scoreT.text = Judge.SCORE.ToString("D6");
        comboT.text = Judge.COMBO.ToString("D4");
        LIFET.text = Judge.LIFE.ToString("D4");
        PGREATT.text = Judge.PGREAT.ToString("D4");
        GREATT.text = Judge.GREAT.ToString("D4");
        POORT.text = Judge.POOR.ToString("D4");
        hispeedT.text = HiSpeed._tens + "." + HiSpeed._ones;

        if(Judge.game == 1)
        {
            GAMET.text = "faired...";
            var colorset = new Color(220,20, 60);
            var color = _target.color;
            color = colorset;
        }
        if(Judge.game == 2)
        {
            GAMET.text = "cleard.";
            var colorset = new Color(135, 206, 250);
            var color = _target.color;
            color = colorset;
        }
    }
    void Update()
    {
        _time += Time.deltaTime;
        var alpha = Mathf.Cos(2 * Mathf.PI * (float)(_time / _cycle)) * 0.5f +1.0f;
        var color = _target.color;
        color.a = alpha;
        _target.color = color;
        if ((Input.GetKeyDown(KeyCode.Keypad5)) || (Input.GetKeyDown(KeyCode.Return)))
        {
            if (PressEnterKey == 1)
            {
                Initiate.Fade("ModeSelect", Color.black, 1.0f);
            }
            if (PressEnterKey == 0)
            {
                StartCoroutine(ResMove());
                PressEnterKey = 1;
            }
            
        }
    }
    IEnumerator ResMove()
    {
        for (int i = 0; i <= 50; i++)
        {
            a.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            b.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            c.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            d.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            e.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            f.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            g.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            h.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            ia.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            j.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            k.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            l.position -= new Vector3(Screen.width / 50, 0.0f, 0.0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
