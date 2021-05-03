using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");

    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");

    }
}