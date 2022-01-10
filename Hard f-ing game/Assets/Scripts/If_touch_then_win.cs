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
    public bool linecrossed = true;
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision ObjectCollidedWith)
    {   
        
        if (ObjectCollidedWith.collider.tag == "Line")
        {
            
            AudioSource.PlayOneShot(Start, new Vector3(0, 0, 0));
            Debug.Log("Let's start!");
            AudioSource.PlayClipAtPoint(BackgroundMusic, new Vector3(0, 0, 0));
            
            

        }
        if (ObjectCollidedWith.collider.tag == "WinBlock")
        {
            AudioSource.PlayClipAtPoint(Win, new Vector3(0, 0, 0));
            Debug.Log("You have won!");
        }

    }
}
