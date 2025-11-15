using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputActions _inputActions;
    private GameObject _boule;
    private Animator _catAnimator;
    private Rigidbody _rb;
    private Vector3 _frwd;
    private float _currentSpeed;
    
    private float SPEED = 1f;
    private float RUNNING_SPEED = 5f;
    
    public void Awake()
    {
        _inputActions = new InputActions();
    }
    
    public void Start()
    {
        _inputActions.Enable();
        _catAnimator = GameObject.FindWithTag("Cat").GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector2 curMoveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        bool isRunning = _inputActions.Player.Sprint.IsPressed();
        curMoveInput.Normalize();

        _catAnimator.SetBool("isRunning", isRunning);
        _catAnimator.SetBool("isMoving", false);

        if (math.lengthsq(curMoveInput) > float.Epsilon)
        {
            _currentSpeed = isRunning ? RUNNING_SPEED : SPEED;
            var move = curMoveInput * (_currentSpeed * Time.deltaTime);
            var forward = new Vector3(move.y, 0, -move.x);
            
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 flattened = Vector3.ProjectOnPlane(cameraForward, Vector3.up);
            Quaternion cameraOrientation = Quaternion.LookRotation(flattened);

            _frwd = cameraOrientation * forward;
            transform.position += _frwd;
            
            _catAnimator.SetBool("isMoving", true);
        }
    }

    public void FixedUpdate()
    {
        _rb.AddTorque(_frwd * (10000 * _currentSpeed));
    }
}