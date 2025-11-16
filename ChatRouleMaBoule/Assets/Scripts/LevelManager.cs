using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        private bool[] Levels { get; set; }
        [SerializeField]
        private TextMeshProUGUI _text;

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
            _text.text = $"{int.Parse(_text.text) + 1}";
        }
        
        public void StarCollected()
        {
            // TODO : Update Score TMP
            CompleteLevel();
        }

        public void Level1()
        {
            SceneManager.LoadScene("level_2");
        }
        
        public void Level2()
        {
            if (Levels[0])
                SceneManager.LoadScene("level_3");
        }
        
        public void Level3()
        {
            if (Levels[1])
                SceneManager.LoadScene("level_4");
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

        public void ManageLocks()
        {
            if (GameObject.Find("Levels Panel") != null)
            {
                if (Levels[0])
                {
                    var lock2 = GameObject.Find("Lock 2");
                    lock2.gameObject.SetActive(false);

                    var level2 = GameObject.Find("Level 2").GetComponent<Image>();
                    var colorlvl2 = level2.color;
                    colorlvl2.a = 1;
                    level2.color = colorlvl2;
                }
                else
                {
                    var lock2 = GameObject.Find("Lock 2");
                    lock2.gameObject.SetActive(true);

                    var level2 = GameObject.Find("Level 2").GetComponent<Image>();
                    var colorlvl2 = level2.color;
                    colorlvl2.a = 0.157f;
                    level2.color = colorlvl2;
                }

                if (Levels[1])
                {
                    var lock3 = GameObject.Find("Lock 3");
                    lock3.gameObject.SetActive(false);

                    var level3 = GameObject.Find("Level 3").GetComponent<Image>();
                    var colorlvl3 = level3.color;
                    colorlvl3.a = 1;
                    level3.color = colorlvl3;
                }

                else
                {
                    var lock3 = GameObject.Find("Lock 3");
                    lock3.gameObject.SetActive(true);

                    var level3 = GameObject.Find("Level 3").GetComponent<Image>();
                    var colorlvl3 = level3.color;
                    colorlvl3.a = 0.157f;
                    level3.color = colorlvl3;
                }
            }
        }
    }
}