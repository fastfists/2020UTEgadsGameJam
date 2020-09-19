using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isPaused = false;
   public void playGame()
    {
        SceneManager.LoadScene(1);
        isPaused = false;
        Time.timeScale = 1;
    }
    public void exitToMain()
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
    public bool getPauseStatus()
    {
        return isPaused;
    }
}
