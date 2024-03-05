using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _time = 0;
    private float _timerInterval = 1;
    private float _tick;


    private void Awake()
    {
        _time = Time.time;
        _tick = _timerInterval;
    }


    private void Update()
    {
        _time = Time.time;
    }
}
