using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayWords : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

   private List<string> numbers = new List<string>() { "one","two", "three", "four", "five", "six", "seven" };
    // Start is called before the first frame update
    void Start()
    {
        // Start displaying the numbers
        StartCoroutine(DisplayNumbers());
    }

    IEnumerator DisplayNumbers()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            // Display the current number
            textMeshPro.text = numbers[i].ToString();

            // Wait for a short period of time before displaying the next number
            yield return new WaitForSeconds(1.0f);
        }

        // Clear the text after all numbers have been displayed
        textMeshPro.text = "";
    }
}