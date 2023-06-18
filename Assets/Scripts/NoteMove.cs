using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteMove : MonoBehaviour
{
    public GameObject destination;
    public void Move(float Movetime)
    {

        transform.DOMove(destination.transform.position, Movetime).SetEase(Ease.Linear);
    }
}
