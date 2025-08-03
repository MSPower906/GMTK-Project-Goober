using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

   public void Resume()
   {
        Time.timeScale = 1;
        gameObject.SetActive(false);
   }

   public void MainMenu()
   {
        SceneManager.LoadScene("Main Menu");
   }

    public void Quit()
    {
       Application.Quit(); 
    }
}
