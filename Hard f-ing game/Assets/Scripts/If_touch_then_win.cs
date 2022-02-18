using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class If_touch_then_win : MonoBehaviour
{
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
    public GameObject Instruct; //Instructions for the player
    public GameObject DeadText; // In case of the player are too dull to follow intruction, remind them to land on the wall
    public Button Next;
    public Button Menu;
    public Button quit;
    private bool GameRestarted;
    private Vector3 velocity;
    private Cube_movement moveScript;

    public void Start()
    {
        GameRestarted = false;
        DeadText.SetActive(false);
    }

    private void Update()
    {
        Float_Noti = gameObject.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
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
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
        }
        else if (ObjectCollidedWith.collider.tag == "Middle_line" && playOnce == false)
        {
            AudioSource.PlayClipAtPoint(Noti, new Vector3(0, 0, 0));
            GameObject prefab = Instantiate(FloatingNoti, new Vector3(20.4f, 46.11f, 0f), Quaternion.identity);
            Debug.Log("Line crossed");
            StartCoroutine(MazeGenerate());
            playOnce = true;
        }
        else if (ObjectCollidedWith.collider.tag == "Ground_Dead")
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
        else if (ObjectCollidedWith.collider.tag == "Next lev block")
        {
            Debug.Log("Loading lv2 extend");
            SceneManager.LoadScene("2(Extended)");
        }
    }

    private IEnumerator MazeGenerate()
    {
        yield return new WaitForSeconds(0.7f);
        AudioSource.PlayClipAtPoint(Pop, new Vector3(0, 0, 0));
        GameObject prefab = Instantiate(Maze, new Vector3(6.95f, -258.48f, 88.75381f), Quaternion.identity);
        
    }
}