using System.Collections;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Player")
        {
            StartCoroutine(Waittt());

            Debug.Log("Door secret");
        }
    }

    private IEnumerator Waittt()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}