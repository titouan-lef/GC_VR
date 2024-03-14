using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyLuke : MiniGame
{
    private float _timeToShoot;
    private float _startTime;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        allTargets = GameObject.FindGameObjectsWithTag("Target");
        SortTargets();
        _canPlayerPlay = false;
        _timeToShoot = 10.0f/(float)_difficulty;

        scoreTable = FindAnyObjectByType<ScoreTable>();
    }

    public override void StartMiniGame(int difficulty)
    {
        allTargets = GameObject.FindGameObjectsWithTag("Target");
        SortTargets();
        _difficulty = difficulty;
        _timeToShoot = 10.0f / (float)_difficulty;
        float timeToPrepare = Random.Range(2.0f, 5.0f);
        _score = 0;

        StartCoroutine(MakeLuckyLuke());

        IEnumerator MakeLuckyLuke()
        {
            // Preparation Time
            Debug.Log("Prepare");
            yield return new WaitForSeconds(timeToPrepare);

            // Light All Up
            _canPlayerPlay = true;
            foreach(var target in allTargets)
            {
                target.GetComponent<Target>().SwitchLightOn();
            }
            Debug.Log("DRAW !");
            _startTime = Time.time;
            scoreTable.StartScoreTable();
            StartCoroutine(EndLuckyLuke());
        }
    }

    private IEnumerator EndLuckyLuke()
    {
        yield return new WaitForSeconds(_timeToShoot);
        _canPlayerPlay = false;
        
        if (_score < allTargets.Length)
        {
            foreach (var target in allTargets)
            {
                target.GetComponent<Target>().SwitchLightOff();
            }
            Debug.Log("You Lose !");
            ResetScoreTable();
        }
    }

    public override void TouchedTarget(int id)
    {
        if (_canPlayerPlay)
        {
            if (allTargets[id].GetComponent<Target>().IsLightOn())
            {
                allTargets[id].GetComponent<Target>().SwitchLightOff();
                _score++;
                scoreTable.DecrementScore();
                if (_score == allTargets.Length)
                {
                    Debug.Log("You Win !");
                    _canPlayerPlay = false;

                    // Trigger Event for Game Manager
                    LevelUp();
                }
            } else
            {
                Debug.Log("Deja Touchée");
            }
        }
    }

    public float GetTimeToShoot(int difficulty)
    {
        _timeToShoot = 10.0f / (float)difficulty;
        return _timeToShoot;
    }
}
