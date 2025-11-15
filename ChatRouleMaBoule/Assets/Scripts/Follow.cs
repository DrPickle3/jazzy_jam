using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class Follow : MonoBehaviour
    {
        [SerializeField]
        private Vector3 offset;
        private GameObject _bouleToFollow;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _bouleToFollow = GameObject.FindWithTag("Boule");
        }

        // Update is called once per frame
        void LateUpdate()
        {
            var boolTransform = _bouleToFollow.transform;


            if(gameObject == Camera.main.gameObject)
            {}
                //transform.LookAt(boolTransform.position);
            else
            {
                transform.position = boolTransform.position + offset;
            }
        }
    }
}