using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class MiniGame : MonoBehaviour
{
    [SerializeField]
    private LevelUpEvent _levelUpEvent;

    [SerializeField]
    protected int _difficulty;

    protected bool _canPlayerPlay;

    protected GameObject[] allTargets;

    protected void SortTargets()
    {
        for (int i = 1; i < allTargets.Length; i++)
        {
            GameObject key = allTargets[i];
            int j = i - 1;
            while (j >= 0 && allTargets[j].GetComponent<Target>().associatedKey > key.GetComponent<Target>().associatedKey)
            {
                allTargets[j + 1] = allTargets[j];
                j = j - 1;
            }
            allTargets[j + 1] = key;
        }
    }

    public abstract void TouchedTarget(int id);

    public abstract void StartMiniGame(int difficulty);

    protected void LevelUp()
    {
        _levelUpEvent.Raise();
    }
}
