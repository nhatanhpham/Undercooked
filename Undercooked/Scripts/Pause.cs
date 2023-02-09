using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            PauseMenu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
    public void Resume()
    {
        isPaused = !isPaused;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
