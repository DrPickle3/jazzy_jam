using UnityEngine;
using UnityEngine.Mathematics;
using UnityEngine.Transforms;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Position _offset;
    private GameObject _bouleToFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bouleToFollow = GameObject.FindWithTag("Boule");
    }

    // Update is called once per frame
    void Update()
    {
        var boolTransform = _bouleToFollow.transform;

        transform.position = boolTransform.position + _offset;

        transform.LookAt(boolTransform.position);
    }
}
