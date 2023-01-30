using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string levelOne;
    public void StartGame()
    {
        SceneManager.LoadScene(levelOne);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
