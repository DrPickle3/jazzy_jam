using System.IO;
using System.Linq;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CoinOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject canva;
        public void Awake()
        {
            if (SceneManager.GetActiveScene().handle == 0)
            {
                canva.SetActive(false);
            }
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.handle == 0)
            {
                canva.SetActive(false);
            }
            else
            {
                canva.SetActive(true);
            }
        }

        public void OnReturnToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}