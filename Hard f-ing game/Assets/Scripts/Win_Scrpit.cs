using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win_Scrpit : MonoBehaviour
{
    public Button Next;
    public Button Menu;
    public Button quit;
    private SceneManager currentScene;

    void Start()
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
}
