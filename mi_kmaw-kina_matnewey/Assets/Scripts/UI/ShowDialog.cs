using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    public GameObject Dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Dialog != null)
        {
            if(collision.tag == "Player")
            {
                Dialog.SetActive(true);
            }   
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (Dialog != null)
        {
            if (collision.tag == "Player")
            {
                Dialog.SetActive(false);
            }   
        }
    }
}
