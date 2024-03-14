using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _rangeTuto;
    private int _tutolevel;

    private void Start()
    {
        _tutolevel = 0;
    }
    public void ChangePannels()
    {
        _tutolevel++;
        switch (_tutolevel)
        {
            case 1:
                _rangeTuto.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Simon";
                _rangeTuto.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "A sequence will be diplayed on the targets. Wait for its end and Repeat it to win. Hit the Buzzer when Ready";

                for (int i = 3; i > 0; i--)
                {
                    Destroy(_rangeTuto.transform.GetChild(i).gameObject);
                }
                break;
            case 2:
                _rangeTuto.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Lucky Luke";
                _rangeTuto.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "All Targets will flash at once. Shoot them all before the time runs out. Hit the Buzzer when Rready.";
                break;
            case 3:
                _rangeTuto.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Turn Around";
                _rangeTuto.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "To continue the tutorial";
                break;
            case 4:
                SceneManager.LoadScene("Map");
                break;
        }
    }
}
