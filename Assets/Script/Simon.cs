using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    private GameObject[] allTargets;

    [SerializeField]
    private int _difficulty = 3;

    private int[] _simonOrder;
    private int _playerCurrentOrder;
    private bool _canPlayerPlay;

    // Start is called before the first frame update
    void Start()
    {
        _simonOrder = new int[_difficulty];
        allTargets = GameObject.FindGameObjectsWithTag("Target");
        _playerCurrentOrder = 0;
        _canPlayerPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            // Random Order every time
            for (int i = 0; i < _difficulty; i++)
            {
                _simonOrder[i] = Random.Range(0, allTargets.Length);
            }

            // Display Order
            StartCoroutine(MakeSimon());

            IEnumerator MakeSimon()
            {
                Debug.Log("Memorize");
                for (int i = 0; i < _difficulty; i++)
                {
                    yield return new WaitForSeconds(.5f);
                    allTargets[_simonOrder[i]].GetComponent<Target>().ToggleLight();
                    yield return new WaitForSeconds(.5f);
                    allTargets[_simonOrder[i]].GetComponent<Target>().ToggleLight();
                }
                Debug.Log("Your Turn");
                _canPlayerPlay = true;
            }


        }
    }

    public void TouchedTarget(int id)
    {
        if (_canPlayerPlay)
        {
            Debug.Log(id.ToString());

            if (_playerCurrentOrder == _difficulty - 1 && id == _simonOrder[_playerCurrentOrder])
            {
                Debug.Log("WON");
                _canPlayerPlay = false;
            }

            if (id != _simonOrder[_playerCurrentOrder])
            {
                Debug.Log("FAILED");
                _canPlayerPlay = false;
            }

            _playerCurrentOrder = _canPlayerPlay ? _playerCurrentOrder + 1 : 0;
            
        } else
        {
            Debug.Log("Not Your Turn !");
        }      
    }
}
