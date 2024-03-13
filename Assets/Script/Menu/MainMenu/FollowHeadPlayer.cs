using UnityEngine;

public class FollowHeadPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Transform _head;

    // Update is called once per frame
    void Update()
    {
        _menu.transform.LookAt(new Vector3(_head.position.x, _menu.transform.position.y, _head.position.z));
        _menu.transform.forward *= -1;
    }
}
