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
    private string str = "hello";
    [SerializeField] private GameObject FloatingNoti;
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Line")
        {

            AudioSource.PlayClipAtPoint(Start, new Vector3(0, 0, 0));
            Debug.Log("Let's start!");
        }

        if (ObjectCollidedWith.collider.tag == "WinBlock")
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
            SceneManager.LoadScene("Win_Screen");
            DontDestroyOnLoad(this.gameObject);
        }

        if (ObjectCollidedWith.collider.tag == "Base")
        {
            AudioSource.PlayClipAtPoint(Noti, new Vector3(0, 0, 0));
            Debug.Log("Line crossed");
            ShowNoti(str);
        }
    }
        void ShowNoti(string text)
        {
            if (FloatingNoti)
            {
                GameObject prefab = Instantiate(FloatingNoti, transform.position, Quaternion.identity);
                prefab.GetComponentInChildren<TextMesh>().text = text;            
            }
        }
}