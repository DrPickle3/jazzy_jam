using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void PlayGame()
   {
    SceneManager.LoadScene("LevelSelect");
   }
   public void QuitGame()
   {
    Debug.Log("Quitting game...");
    Application.Quit();
   } 
}
 