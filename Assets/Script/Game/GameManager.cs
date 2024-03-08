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
    }

    public void SelectLevel(int level)
    {
        if (level == 69)
        {
            StartLevel(_level);
        }
        else
        {
            Debug.Log("Selected Level " + level);
            _level = level;
        }
    }
}
