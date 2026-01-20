using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    public float timeToLive = 3.0f;

    void Awake()
    {
        Destroy(gameObject, timeToLive);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
