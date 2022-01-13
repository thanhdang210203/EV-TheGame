using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Noti : MonoBehaviour
{
    [SerializeField] private float DestroyIn = 3.0f;
    
    void Start()
    {
        Destroy(gameObject, DestroyIn);
    }

    
}
