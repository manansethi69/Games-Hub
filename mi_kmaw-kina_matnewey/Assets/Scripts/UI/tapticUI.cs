using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tapticUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalButtonSize;
    private float sizeIncreaseFactor = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        // Get data
        originalButtonSize = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalButtonSize * sizeIncreaseFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalButtonSize;
    }
}
