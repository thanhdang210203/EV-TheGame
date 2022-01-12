using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class If_touch_then_win : MonoBehaviour
{
    public AudioClip Start;
    public AudioClip BackgroundMusic;
    public AudioClip Win;
    public AudioClip Noti;
    private string str = "hello";
    [SerializeField] private GameObject FloatingNoti;
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {   
        
        if (ObjectCollidedWith.collider.tag == "Object")
        {
            if(this.gameObject.tag == "Line")
            {
                AudioSource.PlayClipAtPoint(Start, new Vector3(0, 0, 0));
                Debug.Log("Let's start!");
                AudioSource.PlayClipAtPoint(BackgroundMusic, new Vector3(0, 0, 0));
            }

            else if (this.gameObject.tag == "WinBlock")
            {
                AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
                Debug.Log("You have won!");
            }

            else if (this.gameObject.tag == "Base")
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
}
