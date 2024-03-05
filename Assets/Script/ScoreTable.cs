using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textTimer;
    [SerializeField] private TextMeshPro _textScore;

    [SerializeField] private float _StartTime = 10;

    private float _time;
    private int _score;

    private void Awake()
    {
        Reset();
    }

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            _textTimer.text = _time.ToString("F2");
        }
        else
        {
            _textTimer.text = "0,00";
        }

        _textScore.text = _score.ToString();
    }

    public void Reset()
    {
        _time = _StartTime;
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void IncrementScore()
    {
        ++_score;
    }
}
