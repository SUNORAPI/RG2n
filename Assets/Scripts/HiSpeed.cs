using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiSpeed : MonoBehaviour
{
    [SerializeField] public GameObject Hst;
    [SerializeField] public GameObject Hso;
    public static float Speed;
    public static int _ones;
    public static int _tens;
    void Awake()
    {
        _ones = 1;
        _tens = 0;
        Speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Keypad7)||(Input.GetKeyDown(KeyCode.UpArrow)))&&(Speed < 9.9f))
        {
            _ones++;
        }

        if ((Input.GetKeyDown(KeyCode.Keypad1)||(Input.GetKeyDown(KeyCode.LeftArrow)))&&(Speed < 9.0f))
        {
            _tens++;
        }

        if((Input.GetKeyDown(KeyCode.Keypad3)||(Input.GetKeyDown(KeyCode.DownArrow)))&&(Speed > 0.1f))
        {
            _ones--;
        }

        if((Input.GetKeyDown(KeyCode.Keypad9)||(Input.GetKeyDown(KeyCode.RightArrow)))&&(Speed > 1.0f))
        {
            _tens--;
        }

        if(_ones == 10)
        {
            _ones= 0;
            _tens++; 
        }

        if (_ones == -1)
        {
            _ones = 9;
            _tens--;
        }

        Speed = 1 * _tens + 0.1f * _ones;
        //Debug.Log(Speed);
        Text HspeedT = Hst.GetComponent<Text>();
        Text HspeedO = Hso.GetComponent<Text>();
        HspeedT.text = _tens.ToString();
        HspeedO.text = _ones.ToString();

        if ((Input.GetKeyDown(KeyCode.Keypad4)) || (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            Judger.keys = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Keypad8)) || (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            Judger.keys = 1;
        }

            if ((Input.GetKeyDown(KeyCode.Keypad5))||(Input.GetKeyDown(KeyCode.Return)))
        {
            Initiate.Fade("ModeSelect", Color.black, 1.0f);
        }
    }
}
