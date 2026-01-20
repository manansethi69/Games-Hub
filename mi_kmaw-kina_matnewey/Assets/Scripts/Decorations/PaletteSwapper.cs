using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwapper : MonoBehaviour
{
    public Color Hue;
    private SpriteRenderer Sprite;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Sprite.color = Hue;
    }
}
