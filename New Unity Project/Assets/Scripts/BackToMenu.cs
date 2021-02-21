using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void ToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
