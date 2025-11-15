using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputActions _inputActions;
    private GameObject _boule;
    private GameObject _camera;
    private Animator _catAnimator;
    
    private float SPEED = 1f;
    private float RUNNING_SPEED = 5f;
    
    public void Awake()
    {
        _inputActions = new InputActions();
    }
    
    public void Start()
    {
        _inputActions.Enable();
        _boule = GameObject.FindWithTag("Boule");
        _catAnimator = gameObject.GetComponentInChildren<Animator>();

    }
    public void Update()
    {
        Vector2 curMoveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        bool isRunning = _inputActions.Player.Sprint.IsPressed();
        curMoveInput.Normalize();

        var speed = isRunning ? RUNNING_SPEED : SPEED;
        var move = curMoveInput * speed * Time.deltaTime;
        var forward = new Vector3(move.x, 0, move.y);
        gameObject.transform.position += forward;
        _catAnimator.SetBool("isRunning", isRunning);
        _catAnimator.SetBool("isMoving", false);

        if (math.lengthsq(forward) > float.Epsilon)
        {
            if(!isRunning)
                _catAnimator.SetBool("isMoving", true);
            
            _boule.transform.rotation = Quaternion.LookRotation(forward, math.up());
        }
    }
}