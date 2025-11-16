using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CoinOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject canva;
        [SerializeField] private GameObject menuCanva;
        [SerializeField] private TextMeshProUGUI text;
        private InputActions _inputActions;
        private int _coinAmount;

        public void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                canva.SetActive(false);
            }
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            _inputActions = new();
            _coinAmount = 0;
        }

        public void Update()
        {
            bool pause = _inputActions.Player.Pause.IsPressed();
            if (pause)
            {
                PauseGame();
            }
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
                _inputActions.Enable();
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            menuCanva.SetActive(true);
        }

        public void OnReturnToMenu()
        {
            OnResumeGame();
            _inputActions.Disable();
            SceneManager.LoadScene(0);
        }

        public void OnResumeGame()
        {
            Time.timeScale = 1;
            menuCanva.SetActive(false);
        }

        public void OnDestroy()
        {
            _inputActions.Disable();
        }
    }
}