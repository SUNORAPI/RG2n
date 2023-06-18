using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _Selecter =new SpriteRenderer[3] ;
    [SerializeField] private SpriteRenderer _target;
    [SerializeField] private float _cycle = 1.0f;
    private SpriteRenderer _nottarget1;
    private SpriteRenderer _nottarget2;
    private float _time = 4.0f;
    private int _select = 0;

    private void Start()
    {
        GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&(_select >0))
        {
            _select--;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && (_select < 2))
        {
            _select++;
        }

        _target = _Selecter[_select];

        _time += Time.deltaTime;
        var alpha = Mathf.Cos(2 * Mathf.PI * (float)(_time/_cycle))*0.5f+0.5f ;
        var color = _target.color;
        color.a = alpha;
        Debug.Log(alpha);
        _target.color = color;

        if( _select == 0)
        {
            _nottarget1 = _Selecter[_select +1];
            _nottarget2 = _Selecter[_select +2];
            transform.position = new Vector3(0,-0.125f,1);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Initiate.Fade("MusicSelect", Color.black, 1.0f);
            }
        }

        if( _select == 1)
        {
            _nottarget1 = _Selecter[_select -1];
            _nottarget2 = _Selecter[_select +1];
            transform.position = new Vector3(0, -1.775f, 1);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Initiate.Fade("Option", Color.black, 1.0f);
            }
        }

        if(_select == 2)
        {
            _nottarget1 = _Selecter[_select -1];
            _nottarget2 = _Selecter[_select -2];
            transform.position = new Vector3(0, -3.455f, 1);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Initiate.Fade("Exit", Color.black, 1.0f);
            }
        }

        var alphanot = 255;
        var colornot1 = _nottarget1.color;
        var colornot2 = _nottarget2.color;
        colornot1.a = alphanot;
        colornot2.a = alphanot;
        _nottarget1.color = colornot1;
        _nottarget2.color = colornot2;
        
    }
}
