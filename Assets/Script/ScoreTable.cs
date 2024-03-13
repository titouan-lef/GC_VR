using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textTimer;
    [SerializeField] private TextMeshPro _textTarget;

    private float _time;
    private int _targetNumber;

    private void Awake()
    {
        Reset();
    }

    private IEnumerator UpdateScoreTable()
    {
        while (_time > 0 && _targetNumber > 0)
        {
            _time -= Time.deltaTime;
            _textTimer.text = _time.ToString("F2");
            _textTarget.text = _targetNumber.ToString();
            yield return null;
        }

        if (_time <= 0)
            _textTimer.text = "0,00";

        _textTarget.text = _targetNumber.ToString();
    }

    public void StartScoreTable()
    {
        StartCoroutine(UpdateScoreTable());
    }

    public void ResetAffichage(float time, int targetNumber)
    {
        _time = time;
        _targetNumber = targetNumber;

        _textTimer.text = _time.ToString("F2");
        _textTarget.text = _targetNumber.ToString();
    }

    public void Reset()
    {
        _time = 0;
        _targetNumber = 0;
    }

    public void DecrementScore()
    {
        --_targetNumber;

        Debug.Log("Decrement");

        if (_targetNumber < 0)
            _targetNumber = 0;

        _textTarget.text = _targetNumber.ToString();
    }
}
