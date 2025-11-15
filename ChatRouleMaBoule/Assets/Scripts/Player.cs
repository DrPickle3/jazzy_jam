using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private InputActions _inputActions;
    private GameObject _cat;
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
        _cat = GameObject.FindWithTag("Cat");
        _catAnimator = _cat.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector2 curMoveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        bool isRunning = _inputActions.Player.Sprint.IsPressed();
        curMoveInput.Normalize();
        
        _frwd = Vector3.zero;

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

            var frwdWorld = transform.TransformDirection(_frwd);
            UnityEngine.Debug.DrawRay(gameObject.transform.position, frwdWorld  * 100, UnityEngine.Color.magenta, 2f);
            _cat.transform.rotation = Quaternion.LookRotation( new Vector3(0-_frwd.z, 0, _frwd.x));
            _catAnimator.SetBool("isMoving", true);
        }

        if (transform.position.y < -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().handle);
        }
    }

    public void FixedUpdate()
    {
        _rb.AddTorque(_frwd * (10000 * _currentSpeed));
    }
}