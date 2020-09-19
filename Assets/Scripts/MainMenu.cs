using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   private bool isPaused = false;


   public void PlayGame()
    {
        SceneManager.LoadScene(1);
        isPaused = false;
        Time.timeScale = 1;
    }
    public void ExitToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;   
    }
    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    public bool GETPauseStatus()
    {
        return isPaused;
    }
}
