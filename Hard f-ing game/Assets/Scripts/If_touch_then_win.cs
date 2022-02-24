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
    public AudioSource music;
    public GameObject FloatingNoti;
    public Rigidbody player;
    [SerializeField] private GameObject Maze;
    private Animation Float_Noti;
    private bool playOnce = true;
    public GameObject Door_Fake;
    public GameObject Door_Fake2;
    public GameObject Door_Rotate;
    public GameObject Warn_Sign;
    public AudioClip Door_Open;
    public GameObject WinMenu;
    public GameObject FailMenu;
    public GameObject Instruct; //Instructions for the player

    // In case of the player are too dull to follow intruction, remind them to land on the wall
    public Button Next;

    public Button Menu;
    public Button quit;

    private Cube_movement moveScript;
    public int coin;

    public void Start()
    {
        player = GetComponent<Rigidbody>();
        FloatingNoti.SetActive(false);
        Door_Rotate.SetActive(false);
        Door_Fake2.SetActive(false);
        Warn_Sign.SetActive(false);
    }

    private void Update()
    {
        Float_Noti = gameObject.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Line" && playOnce == true)
        {
            Debug.Log("Let's start!");
            AudioSource.PlayClipAtPoint(StartGame, new Vector3(0, 0, 0));
           
            playOnce = false;
        }
        else if (ObjectCollidedWith.collider.tag == "Middle_line" && playOnce == false)
        {
            AudioSource.PlayClipAtPoint(Noti, new Vector3(0, 0, 0));
            FloatingNoti.SetActive(true);
            Debug.Log("Line crossed");
            StartCoroutine(MazeGenerate());
            playOnce = true;
        }
        else if (ObjectCollidedWith.collider.tag == "warn")
        {
            Warn_Sign.SetActive(true);
            
        }
        else if (ObjectCollidedWith.collider.tag == "Next lev block")
        {
            Debug.Log("Loading lv2 extend");
            SceneManager.LoadScene("2(Extended)");
        }
        else if (ObjectCollidedWith.collider.tag == "Coin")
        {
            coin = coin + 1;
        }
        else if (ObjectCollidedWith.collider.tag == "Door fake")
        {
            Destroy(Door_Fake);
            Door_Rotate.SetActive(true);
            AudioSource.PlayClipAtPoint(Door_Open, new Vector3(-4.3f, 1.03f, 19.0f));
            StartCoroutine(theDoors());

            Debug.Log("jjjj");
        }
        else if (ObjectCollidedWith.collider.tag == "WinBlock" && coin == 3)
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
            music.Pause();
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
        }
        else if (ObjectCollidedWith.collider.tag == "WinBlock" && coin < 3)
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
            Time.timeScale = 0f;
            FailMenu.SetActive(true);
        }
        else if (ObjectCollidedWith.collider.tag == "win_final" && coin == 3)
        {
            SceneManager.LoadScene("Secret Level");
        }
    }

    private IEnumerator MazeGenerate()
    {
        yield return new WaitForSeconds(0.7f);
        AudioSource.PlayClipAtPoint(Pop, new Vector3(0, 0, 0));
        GameObject prefab = Instantiate(Maze, new Vector3(6.84000015f, -258.339996f, 91.25f), Quaternion.identity);
    }

    private IEnumerator theDoors()
    {
        yield return new WaitForSeconds(2f);
        Door_Fake2.SetActive(true);
    }
}