using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiSpeed : MonoBehaviour
{
    [SerializeField] public GameObject Hst;
    [SerializeField] public GameObject Hso;
    public static float Speed;
    private int _ones;
    private int _tens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow))&&(Speed < 9.9f))
        {
            _ones++;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow))&&(Speed < 9.0f))
        {
            _tens++;
        }

        if((Input.GetKeyDown(KeyCode.DownArrow))&&(Speed > 0.0f))
        {
            _ones--;
        }

        if((Input.GetKeyDown(KeyCode.RightArrow))&&(Speed > 1.0f))
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
        Debug.Log(Speed);
        Text HspeedT = Hst.GetComponent<Text>();
        Text HspeedO = Hso.GetComponent<Text>();
        HspeedT.text = _tens.ToString();
        HspeedO.text = _ones.ToString();

        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Initiate.Fade("ModeSelect", Color.black, 1.0f);
        }
    }
}
