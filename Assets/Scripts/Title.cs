using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] private Text _target;
    [SerializeField] private float _cycle = 1.0f;
    private float _time = 4.0f;
    private void Update()
    {
        _time += Time.deltaTime;
        var alpha = Mathf.Cos(2 * Mathf.PI * (float)(_time/_cycle))*0.5f+0.5f ;
        var color = _target.color;
        color.a = alpha;
        _target.color = color;
    }
}
