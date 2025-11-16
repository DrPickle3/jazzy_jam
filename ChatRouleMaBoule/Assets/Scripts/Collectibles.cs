using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private AudioSource sound;
        private LevelManager _levelManager;

        private MeshRenderer _renderer;
        private MeshCollider _collider;

        public void Start()
        {
            _levelManager = FindFirstObjectByType<LevelManager>();
            _renderer = GetComponentInChildren<MeshRenderer>();           
            _collider = GetComponentInChildren<MeshCollider>();

        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (other == null)
                return;

            if (other.CompareTag("Boule"))
            {
                if (gameObject.CompareTag("Star"))
                {
                    _levelManager.StarCollected();
                }
                else
                {
                    _levelManager.CoinCollected();
                }

                StartCoroutine(PlayAndDestroyRoutine());
                
                sound.Play();
                gameObject.SetActive(false);
                while (sound.isPlaying)
                {
                }

                Destroy(gameObject);
            }
        }
        
        private IEnumerator PlayAndDestroyRoutine()
        {
            _collider.enabled = false;
            _renderer.enabled = false;
            sound.Play();

            // Wait for the clip duration safely
            yield return new WaitWhile(() => sound.isPlaying);

            Destroy(gameObject);
        }
    }
}