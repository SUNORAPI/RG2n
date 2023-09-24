using FancyScrollView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Cell : FancyCell<MusicData,MusicContext>
{
    public override void UpdatePosition(float position)
    {
        musicCellAnimator.Play("CellAnimation",-1,position);
        musicCellAnimator.speed = 0;
    }
    public void OnSelect()
    {
        Context.OnSelectedCell?.Invoke(Index);
        transform.SetAsLastSibling();
    }

    [SerializeField] private Text musicNameText;
    [SerializeField] private Text composer;
    [SerializeField] private Image musicNameBackImage;
    [SerializeField] private Image musicThumbnail;
    [SerializeField] private Animator musicCellAnimator;
    public override void UpdateContent(MusicData musicData)
    {
        musicNameText.text = musicData.musicName.ToString();
        composer.text = musicData.Composer.ToString();
        musicThumbnail.sprite = musicData.MusicIMG;
    }

}
