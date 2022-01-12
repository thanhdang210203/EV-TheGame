using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Noti : MonoBehaviour
{
    [SerializeField] private float DestroyIn = 0.5f;
    
    void Start()
    {
        Destroy(gameObject, DestroyIn);
    }

    
}
