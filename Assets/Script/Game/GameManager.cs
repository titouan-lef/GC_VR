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
    private AudioSource _winLevelSound;

    [SerializeField]
    private List<GameObject> _targetTypes;

    [SerializeField]
    private GameObject _targets;

    [SerializeField]
    private LevelSetup[] _levelSetup;

    [SerializeField]
    private UnityEngine.Vector2[] _levelManager;

    [SerializeField]
    private MaxLevelUpEvent _maxLevelUpEvent;

    private int _level;
    private int _currentMaxLevel;

    private MiniGame[] _allModes;

    private ScoreTable _scoreTable;

    // Start is called before the first frame update
    void Start()
    {
        _level = 1;
        _currentMaxLevel = _level;

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
    }

    private void StartLevel(int level)
    {
        Debug.Log("Starting Level " + level);
        _allModes[(int)_levelManager[level].x].StartMiniGame((int)_levelManager[level].y);
    }

    public void LevelUp()
    {
        if (_level == _currentMaxLevel)
        {
            _maxLevelUpEvent.Raise();
            _currentMaxLevel++;
        }
        _level++;
        SelectLevel(_level);
        _winLevelSound.Play();
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
            var newTarget = Instantiate(_targetTypes[currentLevelSetup.targetsType[i]], currentLevelSetup.targetsPoses[i], currentLevelSetup.targetsRotation[i], _targets.transform);
            newTarget.GetComponent<Target>().associatedKey = i;
        }

        Debug.Log("Selected Level " + level);
        _level = level;

        ResetScoreTable();
    }

    public void ResetScoreTable()
    {
        LevelSetup currentLevelSetup = _levelSetup[_level];
        switch ((int)_levelManager[_level].x)
        {
            case 0:
                break;
            case 1:
                _scoreTable.ResetAffichage(0.0f, (int)_levelManager[_level].y);
                break;
            case 2:
                _scoreTable.ResetAffichage(_luckyLukeManager.GetTimeToShoot((int)_levelManager[_level].y), currentLevelSetup.targetsPoses.Count);
                break;
        }
    }
}
