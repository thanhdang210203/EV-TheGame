using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class If_touch_then_win : MonoBehaviour
{
    public static bool GameWon = false;
    public AudioClip StartGame;
    public AudioClip Win;
    public AudioClip Noti;
    public AudioClip Pop;
    private string str = "PASS THROUGH THE MAZE";
    [SerializeField] private GameObject FloatingNoti;
    [SerializeField] private GameObject Maze;
    private Animation Float_Noti;
    private bool playOnce = true;
    public GameObject WinMenu;
    public GameObject Instruct;
    public GameObject DeadText;
    public Button Next;
    public Button Menu;
    public Button quit;
    private bool GameRestarted;

    public void Start()
    {
        GameWon = false;
        GameRestarted = false;
        DeadText.SetActive(false);
    }
    void Update()
    {
        Float_Noti = gameObject.GetComponent<Animation>();
    }
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Line" && playOnce == true)
        {

            AudioSource.PlayClipAtPoint(StartGame, new Vector3(0, 0, 0));
            Debug.Log("Let's start!");
            playOnce = false;
           
        }

        else if (ObjectCollidedWith.collider.tag == "WinBlock")
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
            WinPop();
            
        }

        else if (ObjectCollidedWith.collider.tag == "Middle_line" && playOnce == false)
        {
            AudioSource.PlayClipAtPoint(Noti, new Vector3(0, 0, 0));
            Debug.Log("Line crossed");
            ShowNoti(str);
            StartCoroutine(MazeGenerate());
            playOnce = true;
        }
        
        else if(ObjectCollidedWith.collider.tag == "Ground_Dead")
        {
            Debug.Log("Dead ground touched, restarting level.....");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameRestarted = true;
            if (GameRestarted)
            {
                Instruct.SetActive(false);
                DeadText.SetActive(true);
            }
        }
    }
    void ShowNoti(string text)
    {
        if (FloatingNoti)
        {
            GameObject prefab = Instantiate(FloatingNoti, new Vector3(20.4f, 41.11f, 34f), Quaternion.identity); 
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }

    void WinPop()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
        GameWon = true;
    }
    IEnumerator MazeGenerate()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject prefab = Instantiate(Maze, new Vector3(6.95f, -258.48f, 88.75381f), Quaternion.identity);
        AudioSource.PlayClipAtPoint(Pop, new Vector3(0, 0, 0));
    }

    IEnumerator DestroyNot()
    {
        yield return new WaitForSeconds(4.0f);
    }

}