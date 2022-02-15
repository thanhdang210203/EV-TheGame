using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Scrpit : MonoBehaviour
{
    private SceneManager currentScene;

    private void Start()
    {
    }

    public void SelectNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

    public void SelectQuit()
    {
        Application.Quit();
        Debug.Log("Quiting game....");
    }

    public void SelectRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}