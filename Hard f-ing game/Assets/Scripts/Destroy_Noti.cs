using UnityEngine;

public class Destroy_Noti : MonoBehaviour
{
    [SerializeField] private float DestroyIn = 3.0f;

    private void Start()
    {
        Destroy(gameObject, DestroyIn);
    }
}