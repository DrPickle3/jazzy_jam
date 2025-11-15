// using System.IO;
// using UnityEngine;
// using UnityEngine.SceneManagement;
//
// using Newtonsoft.Json;
// using Unity.VisualScripting;
//
// namespace DefaultNamespace
// {
//     public class LevelsJSON
//     {
//         [Serialize]
//         public bool[] levels {get; set;}
//     }
//
//     public class LevelManager : MonoBehaviour
//     {
//         private LevelsJSON _levels;
//
//         public void Start()
//         {
//             string jsonLevels = File.ReadAllText("levels.json");
//             _levels = JsonConvert.DeserializeObject<LevelsJSON>(jsonLevels);
//         }
//
//         static void test()
//         {
//             
//         }
//
//         private void CompleteLevel()
//         {
//             
//         }
//
//         private void ResetProgress()
//         {
//             var lvls = new LevelsJSON();
//             string jsonString = JsonSerializer.Serialize(lvls);
//             File.WriteAllText("levels.json", jsonString);
//         }
//     }
// }