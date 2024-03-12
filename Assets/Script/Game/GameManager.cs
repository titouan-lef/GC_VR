using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Tuto _tutoManager;
    private Simon _simonManager;
    private LuckyLuke _luckyLukeManager;

    [SerializeField]
    private Target _target;

    [SerializeField]
    private GameObject _targets;

    [SerializeField]
    private LevelSetup[] _levelSetup;

    [SerializeField]
    private UnityEngine.Vector2[] _levelManager;

    private int _level;

    private MiniGame[] _allModes;

    private ScoreTable _scoreTable;

    // Start is called before the first frame update
    void Start()
    {
        _level = 1;

        _tutoManager = GetComponent<Tuto>();
        _simonManager = GetComponent<Simon>();
        _luckyLukeManager = GetComponent<LuckyLuke>();

        _allModes = new MiniGame[3];

        _allModes[0] = _tutoManager;
        _allModes[1] = _simonManager;
        _allModes[2] = _luckyLukeManager;


        _scoreTable = FindAnyObjectByType<ScoreTable>();

        SelectLevel(1);
    }

    public void StartCurrentLevel()
    {
        StartLevel(_level);
        _scoreTable.StartScoreTable();
    }

    private void StartLevel(int level)
    {
        Debug.Log("Starting Level " + level);
        _allModes[(int)_levelManager[level].x].StartMiniGame((int)_levelManager[level].y);
    }

    public void LevelUp()
    {
        _level++;
        SelectLevel(_level);
    }

    public void SelectLevel(int level)
    {
        // Destroy Previous Targets
        for (int i = 0; i < _targets.transform.childCount; i++)
        {
            Destroy(_targets.transform.GetChild(i).gameObject);
        }

        LevelSetup currentLevelSetup = _levelSetup[level];
        for (int i = 0; i < currentLevelSetup.targetsPoses.Count; i++)
        {
            var newTarget = Instantiate(_target, currentLevelSetup.targetsPoses[i], currentLevelSetup.targetsRotation[i], _targets.transform);
            newTarget.associatedKey = i;
        }

        Debug.Log("Selected Level " + level);
        _level = level;

        switch ((int)_levelManager[level].x)
        {
            case 0:
                break;
            case 1:
                _scoreTable.ResetAffichage(0.0f, (int)_levelManager[level].y);
                break;
            case 2:
                _scoreTable.ResetAffichage(_luckyLukeManager.timeToShoot, currentLevelSetup.targetsPoses.Count);
                break;
        }
        
    }
}
