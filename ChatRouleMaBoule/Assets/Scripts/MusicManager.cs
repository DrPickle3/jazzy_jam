using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusic : MonoBehaviour
{
    private static LevelMusic instance;
    private string originalScene;

    private void Awake()
    {
        // --- Prevent duplicates ---
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        originalScene = SceneManager.GetActiveScene().name;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If same scene → player died → keep music
        if (scene.name == originalScene)
            return;

        // If new scene → destroy the music object completely
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
    }
}