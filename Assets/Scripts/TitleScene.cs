using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        if (Input.anyKey)
        {
            Initiate.Fade("ModeSelect",Color.black,1.0f);
        }
    }
}
