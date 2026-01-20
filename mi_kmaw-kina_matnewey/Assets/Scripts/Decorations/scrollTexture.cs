using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{
    private Material _material;
    private float currentscroll = 0f;
    public float speed = 0f;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        currentscroll += speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(currentscroll, 0);
    }
}
