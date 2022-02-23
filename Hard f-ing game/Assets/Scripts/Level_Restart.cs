using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Restart : MonoBehaviour
{
    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("aaaaaaaaaaaaaa");
        }
    }
}