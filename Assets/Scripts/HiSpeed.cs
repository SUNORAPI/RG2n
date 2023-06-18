using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiSpeed : MonoBehaviour
{
    public static float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Speed += 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Speed -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            Initiate.Fade("ModeSelect", Color.black, 1.0f);
        }
    }
}
