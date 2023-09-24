using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelectMNG : MonoBehaviour
{
    [SerializeField] private MusicSelect musicScrollView;
    [SerializeField] private List<MusicData> musicDataList = new List<MusicData>();
    void Start()
    {
        musicScrollView.UpdateData(musicDataList);
        musicScrollView.SelectCell(0);
    }

    void Update()
    {
        
    }
}
