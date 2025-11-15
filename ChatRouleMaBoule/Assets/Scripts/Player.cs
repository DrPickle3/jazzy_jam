using UnityEngine;

public class Player : MonoBehaviour
{
    private InputActions _inputActions;
    private GameObject _boule;
    
    public void Awake()
    {
        _inputActions = new InputActions();
    }
    
    public void Start()
    {
        _inputActions.Enable();
        _boule = GameObject.FindWithTag("Boule");
    }
    public void Update()
    {
        Vector2 curMoveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        curMoveInput.Normalize();

        _boule.transform.position += new Vector3(curMoveInput.x, 0, curMoveInput.y);
    }
}