using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMenu : MenuSelection
{
    [SerializeField] private GameObject _currentMenu;
    [SerializeField] private GameObject _nextMenu;

    protected override void SelectionnedAction()
    {
        base.SelectionnedAction();
        _currentMenu.SetActive(false);
        _nextMenu.SetActive(true);
    }
}
