using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Collectibles : MonoBehaviour
    {
        [SerializeField] private AudioSource sound;
        private LevelManager _levelManager;

        public void Start()
        {
            _levelManager = FindFirstObjectByType<LevelManager>();
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
            }
        }
        
        private IEnumerator PlayAndDestroyRoutine()
        {
            sound.Play();

            // Wait for the clip duration safely
            yield return new WaitWhile(() => sound.isPlaying);

            Destroy(gameObject);
        }
    }
}