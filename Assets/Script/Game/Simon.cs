using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MiniGame
{
    private int[] _simonOrder;
    private int _playerCurrentOrder;

    // Start is called before the first frame update
    void Start()
    {
        allTargets = GameObject.FindGameObjectsWithTag("Target");
        SortTargets();
        _canPlayerPlay = false;
        _playerCurrentOrder = 0;

        scoreTable = FindAnyObjectByType<ScoreTable>();
    }

    public override void StartMiniGame(int difficulty)
    {
        allTargets = GameObject.FindGameObjectsWithTag("Target");
        SortTargets();
        _difficulty = difficulty;
        _simonOrder = new int[_difficulty];
        // Random Order every time
        for (int i = 0; i < _difficulty; i++)
        {
            _simonOrder[i] = Random.Range(0, allTargets.Length);
        }

        // Display Order
        StartCoroutine(MakeSimon());

        IEnumerator MakeSimon()
        {
            Debug.Log("Memorize");
            for (int i = 0; i < _difficulty; i++)
            {
                yield return new WaitForSeconds(.5f);
                allTargets[_simonOrder[i]].GetComponent<Target>().SwitchLightOn();
                yield return new WaitForSeconds(.5f);
                allTargets[_simonOrder[i]].GetComponent<Target>().SwitchLightOff();
            }
            Debug.Log("Your Turn");
            _canPlayerPlay = true;
        }
    }

    public override void TouchedTarget(int id)
    {
        if (_canPlayerPlay)
        {
            Debug.Log(id.ToString());

            if (_playerCurrentOrder == _difficulty - 1 && id == _simonOrder[_playerCurrentOrder])
            {
                Debug.Log("WON");
                _canPlayerPlay = false;

                // Trigger Event for Game Manager
                LevelUp();
            }

            if (id != _simonOrder[_playerCurrentOrder])
            {
                Debug.Log("FAILED");
                _canPlayerPlay = false;
                ResetScoreTable();
            }

            _playerCurrentOrder = _canPlayerPlay ? _playerCurrentOrder + 1 : 0;

            if (_canPlayerPlay)
            {
                scoreTable.DecrementScore();
                StartCoroutine(Flash());
            }

            IEnumerator Flash()
            {
                allTargets[_simonOrder[id]].GetComponent<Target>().SwitchLightOn();
                yield return new WaitForSeconds(.1f);
                allTargets[_simonOrder[id]].GetComponent<Target>().SwitchLightOff();
            }
        }     
    }
}
