using UnityEngine;

namespace DefaultNamespace
{
    public class Collectibles : MonoBehaviour
    {
        private LevelManager _levelManager;

        public void Start()
        {
            _levelManager = FindFirstObjectByType<LevelManager>();
        }
        
        public void OnTriggerEnter(Collider other)
        {
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
                Destroy(gameObject);
            }
        }
    }
}