using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset;
    public Transform player;
    [Range(0f, 10f)]
    public float turnSpeed;

    private InputActions _actions;
    private Vector2 _oldAngle;

    private void Awake()
    {
        _oldAngle = Vector2.zero;
        _actions = new InputActions();
    }

    private void Start()
    {
        _actions.Enable();
        transform.position += new Vector3(0, 3, 0);
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        var mouse = _actions.Player.Look.ReadValue<Vector2>();
        
        _oldAngle = new Vector2(_oldAngle.x + mouse.x * turnSpeed,
            math.clamp(_oldAngle.y - mouse.y * turnSpeed, -65, 45));

        var quat =
            Quaternion.AngleAxis(_oldAngle.x, Vector3.up) *
            Quaternion.AngleAxis(_oldAngle.y, Vector3.right);

        transform.position = player.position + quat * offset;
        transform.LookAt(player.position);
    }
}