using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetButtons : MonoBehaviour
{
    private List<ButtonPressVisual> _buttons = new List<ButtonPressVisual>();
    private int _currentMaxLevel;
    private int _currentLevel;

    private void Start()
    {
        _currentLevel = 1;
        _currentMaxLevel = _currentLevel;
        foreach (Transform levelButtons in transform)
        {
            foreach (Transform buttons in levelButtons)
            {
                foreach (Transform cubes in buttons)
                {
                    foreach (Transform interactions in cubes)
                    {
                        ButtonPressVisual buttonPressVisual = interactions.GetComponent<ButtonPressVisual>();
                        if (buttonPressVisual)
                            _buttons.Add(buttonPressVisual);
                    }
                }
            }
        }

        _buttons[0].EnableButton();
    }

    public void ResetSelection(int id)
    {
        _currentLevel = id;
        foreach (var button in _buttons)
        {
            if (button.IsEnabled())
            {
                button.Deselect();
            }
        }
    }

    public void UnlockButton()
    {
        Debug.Log("Proc");
        _currentMaxLevel++;
        _buttons[_currentMaxLevel - 1].EnableButton();
    }

    public void LevelUpSelection()
    {
        ResetSelection(_currentLevel);
        _currentLevel++;
        if (_buttons[_currentLevel - 1].IsEnabled())
        {
            _buttons[_currentLevel - 1].Select();
        }
    }
}
