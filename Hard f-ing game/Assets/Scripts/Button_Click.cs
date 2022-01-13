using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Button_Click: MonoBehaviour
{
    public Button start;
    public Button Level;
    public Button quit;
    public AudioClip opener;
    void Start()
    {

    }
    // Start is called before the first frame update
    public void selectStart()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("1");
    }
    public void selectLevel()
    {
        Debug.Log("Level Select");
        SceneManager.LoadScene("Select Level");

    }
    public void selectQuit()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }
    public void selectLevel1()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("1");
        DontDestroyOnLoad(opener);
    }
    public void selectLevel2()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("2");
    }
    public void selectLevel3()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("3");
    }
    public void selectLevel4()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("4");
    }
    public void selectLevelSecret()
    {
        Debug.Log("Loading Level");
        SceneManager.LoadScene("Secret Level");
    }
}
