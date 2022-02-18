using UnityEngine;

public class Coin_Get : MonoBehaviour
{
    public AudioClip Get_Coin;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Get_Coin, new Vector3(0, 0, 0));
            Destroy(gameObject);
            Debug.Log("jjjj");
        }
    }
}