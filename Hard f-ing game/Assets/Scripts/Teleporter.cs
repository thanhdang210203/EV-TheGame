using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "TeleporterA")
        {
            Player.transform.position = new Vector3(0.173360825f, 18.5699997f, 5.84000015f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterA_Exit")
        {
            Player.transform.position = new Vector3(0.173360825f, 1.51999998f, -11.5299997f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterB")
        {
            Player.transform.position = new Vector3(0.173360825f, 18.5599995f, 9.26000023f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterB_Exit")
        {
            Player.transform.position = new Vector3(0.173360825f, 12.5030003f, 15.4099998f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterC")
        {
            Player.transform.position = new Vector3(0.173360825f, 35.4599991f, 24.7199993f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterC_Exit")
        {
            Player.transform.position = new Vector3(0.173360825f, 32.6399994f, 67.3700027f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterD")
        {
            Player.transform.position = new Vector3(0.173360825f, 20.4899998f, 67.6699982f);
        }
        if (ObjectCollidedWith.collider.tag == "TeleporterD_Exit")
        {
            Player.transform.position = new Vector3(0.173360825f, 21.5900002f, 44.2900009f);
        }
    }
}