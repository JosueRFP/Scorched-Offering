using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   void Start()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
   public void Renascer()
   {
     SceneManager.LoadScene("Game");
     Time.timeScale = 1f;
   }
   public void VoltaMenu()
   {
      SceneManager.LoadScene("Menu");
   }
}
