using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace DefaultNamespace
{
    public class LevelsJSON
    {
        [Serialize]
        public bool[] levels {get; set;}
    }

    public class LevelManager : MonoBehaviour
    {

        public void Start()
        {
        }

        private void CompleteLevel()
        {
            
        }

        private void ResetProgress()
        {
            
        }
    }
}