using UnityEngine;

namespace DefaultNamespace
{
    
    public class CameraMovement : MonoBehaviour
    {
        private InputActions _inputActions;
        
        public void Awake()
        {
            _inputActions = new InputActions();
        }

        public float followSpeed = 5f;

        void Update()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;

            mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z; 
            Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Vector3 newCameraPosition = Vector3.Lerp(transform.position, targetWorldPosition, followSpeed * Time.deltaTime);
            transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, transform.position.z);
        }
    }
}