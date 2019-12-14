using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void WinnerScreen()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }


}
