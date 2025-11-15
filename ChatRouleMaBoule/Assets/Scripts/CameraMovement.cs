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

        var oldPos = transform.position;

        var mouse = _actions.Player.Look.ReadValue<Vector2>();
        
        _oldAngle = new Vector2(_oldAngle.x + mouse.x * turnSpeed,
            math.clamp(_oldAngle.y - mouse.y * turnSpeed, -65, 20));

        var quat =
            Quaternion.AngleAxis(_oldAngle.x, Vector3.up) *
            Quaternion.AngleAxis(_oldAngle.y, Vector3.right);

        transform.position = player.position + quat * offset;
        transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
        
        Vector3 pos = transform.position;
        Ray ray = new Ray(player.position, oldPos - player.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (math.length(hit.point - player.position) < math.length(transform.position - player.position))
            {
                pos = hit.point;
            }
        }

        transform.position = pos;
    }
    
    public void OnDestroy()
    {
        _actions.Disable();
    }
}