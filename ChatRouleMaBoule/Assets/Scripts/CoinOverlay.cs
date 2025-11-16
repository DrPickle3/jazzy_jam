using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CoinOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject canva;
        [SerializeField] private TextMeshProUGUI text;
        private InputActions _inputActions;

        public void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                canva.SetActive(false);
            }
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            _inputActions = new();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex == 0)
            {
                canva.SetActive(false);
            }
            else
            {
                text.text = "0";
                canva.SetActive(true);
            }
        }

        public void OnReturnToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void OnDestroy()
        {
            _inputActions.Disable();
        }
    }
}