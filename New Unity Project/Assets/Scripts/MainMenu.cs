using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsScreen;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Debug.Log("IT'S A TRAP, GET OUT!!!");
        Application.Quit();
    }

    public void ShowCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        creditsScreen.SetActive(false);
    }
}
