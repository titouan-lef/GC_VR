using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetButtons : MonoBehaviour
{
    private List<ButtonPressVisual> _buttons = new List<ButtonPressVisual>();

    private void Start()
    {
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
    }

    public void Reset(int id)
    {
        Debug.Log("Reset");
        foreach (ButtonPressVisual button in _buttons)
            button.Deselect();
    }
}
