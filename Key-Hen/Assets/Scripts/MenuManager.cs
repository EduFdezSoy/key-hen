using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GotoAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
