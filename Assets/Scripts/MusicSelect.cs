using FancyScrollView;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasingCore;
public enum Music //ここに曲を追加してください。カンマで区切ってください。
{
    Confront, TeraIOshort
}
public class MusicSelect : FancyScrollView<MusicData, MusicContext>
    {
    [SerializeField] private Scroller musicScroller;
    [SerializeField] private GameObject musicCellPrefab;
    protected override GameObject CellPrefab => musicCellPrefab;
    protected override void Initialize()
    {
        base.Initialize();
        Context.OnSelectedCell = SelectCell;
        musicScroller.OnValueChanged(base.UpdatePosition);
    }
    private int _length = Enum.GetNames(typeof(Music)).Length -1;
    public static Music SelectMusic;

    public void UpdateData(List<MusicData> musicData)
    {
        base.UpdateContents(musicData);
        musicScroller.SetTotalCount(musicData.Count);
    }

    public void UpdateSelection(int index)
    {
        if (index == Context.selectIndex) return;
        Context.selectIndex = index;
        base.Refresh();
    }
    public void SelectCell(int index)
    {
        if (index < 0 || index >= ItemsSource.Count) return;
        UpdateSelection(index);
        musicScroller.ScrollTo(index, 0.35f, Ease.OutCubic);
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Keypad7))||(Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Context.selectIndex = Context.selectIndex + 1;
            SelectCell(Context.selectIndex);
        }
        if ((Input.GetKeyDown(KeyCode.Keypad3))||(Input.GetKeyDown(KeyCode.DownArrow)))
        {
            Context.selectIndex = Context.selectIndex - 1;
            SelectCell(Context.selectIndex);
        }
        if (Context.selectIndex <= -1)
        { 
            Context.selectIndex = _length;
            SelectCell(Context.selectIndex);
        }
        if (Context.selectIndex >= _length +1)
        {
            Context.selectIndex = 0;
            SelectCell(Context.selectIndex);
        }
        SelectMusic = (Music)System.Enum.ToObject(typeof(Music), Context.selectIndex);

        if ((Input.GetKeyDown (KeyCode.Keypad5))||(Input.GetKeyDown(KeyCode.Return)))
        {
            Judge.PGREAT = 0;
            Judge.GREAT = 0;
            Judge.POOR = 0;
            Judge.SCORE = 0;
            Judge.COMBO = 0;
            Judge.game = 0;
            Judge.LIFE = 1000;
            Initiate.Fade("Main", Color.black, 1.0f);
        }
    }
}