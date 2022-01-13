using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;


    void Start()
    {
        GamePaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                StopGame();
            }
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void StopGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("Menu");
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }
}
