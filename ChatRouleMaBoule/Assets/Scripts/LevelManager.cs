using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        private bool[] Levels { get; set; }

        public void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
        public void Start()
        {
            var textLevels = Resources.Load<TextAsset>("levels").text;

            Levels = textLevels
                .Split(',')
                .Select(v => v.Trim().ToLower() == "true")
                .ToArray();
        }

        public void CoinCollected()
        {
            // TODO : Update Score TMP
        }
        
        public void StarCollected()
        {
            // TODO : Update Score TMP
            CompleteLevel();
        }

        private void CompleteLevel()
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            Levels[index - 1] = true;
            
            SaveProgress();
            
            SceneManager.LoadScene(index + 1);
        }

        private void SaveProgress()
        {
            var text = string.Join(",", Levels.Select(b => b ? "true" : "false"));
            File.WriteAllText(Application.dataPath + "/Resources/levels.txt", text);
        }

        private void ResetProgress()
        {
            File.WriteAllText(Application.dataPath + "/Resources/levels.txt", "false,false,false");
        }
    }
}