using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScene : MenuSelection
{
    [SerializeField] private string _sceneToLoad;

    protected override void SelectionnedAction()
    {
        base.SelectionnedAction();
        SceneManager.LoadScene(_sceneToLoad);
    }
}
