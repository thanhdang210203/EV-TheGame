using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class If_touch_then_win : MonoBehaviour
{
    public AudioClip Start;
    public AudioClip Win;
    public AudioClip Noti;
    public AudioClip Pop;
    private string str = "PASS THROUGH THE MAZE";
    [SerializeField] private GameObject FloatingNoti;
    private Animation Float_Noti;
    private bool playOnce = true;
    [SerializeField] private GameObject Maze;
    void Update()
    {
        Float_Noti = gameObject.GetComponent<Animation>();
    }
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Line" && playOnce == true)
        {

            AudioSource.PlayClipAtPoint(Start, new Vector3(0, 0, 0));
            Debug.Log("Let's start!");
            playOnce = false;
        }

        else if (ObjectCollidedWith.collider.tag == "WinBlock")
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
            SceneManager.LoadScene("Win_Screen");
            
        }

        else if (ObjectCollidedWith.collider.tag == "Middle_line" && playOnce == false)
        {
            AudioSource.PlayClipAtPoint(Noti, new Vector3(0, 0, 0));
            Debug.Log("Line crossed");
            ShowNoti(str);
            StartCoroutine(MazeGenerate());
          playOnce = true;
        }
    }
    void ShowNoti(string text)
    {
        if (FloatingNoti)
        {
            GameObject prefab = Instantiate(FloatingNoti, new Vector3(22.5f, 17f, 36.4f), Quaternion.identity); 
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }

    IEnumerator MazeGenerate()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject prefab = Instantiate(Maze, new Vector3(7.273451f, -256.2433f, 88.75381f), Quaternion.identity);
        AudioSource.PlayClipAtPoint(Pop, new Vector3(0, 0, 0));
    }
}