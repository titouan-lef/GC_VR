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
        if (level == 69)
        {
            StartLevel(_level);
        }
        else
        {
            if (level <= 4)
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
            }
        }
    }
}
