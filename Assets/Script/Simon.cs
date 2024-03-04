using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour
{
    GameObject[] allTargets;

    [SerializeField]
    private int _difficulty = 3;

    // Start is called before the first frame update
    void Start()
    {
        allTargets = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Start Simon");
            StartCoroutine(MakeSimon());

            IEnumerator MakeSimon()
            {
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
