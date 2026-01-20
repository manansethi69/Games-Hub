using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class scrollingAssets : MonoBehaviour
{
   [SerializeField] private float xSpeed = 0f;
   [SerializeField] private float ySpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(xSpeed * Time.time, ySpeed * Time.time);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
