using UnityEngine;
using UnityEngine.UI;

public class DropDownController : MonoBehaviour
{
    public GameObject dropDown; // Reference to the dropdown object in the scene
    public Text dropDownText; // Reference to the text component of the dropdown

    private bool isDropDownVisible = false;
    private Dropdown dropdownComponent;

    void Start()
    {
        // Initially, hide the dropdown
        dropDown.SetActive(false);
        dropdownComponent = dropDown.GetComponent<Dropdown>();
        dropdownComponent.onValueChanged.AddListener(delegate { OnDropDownValueChanged(dropdownComponent); });
    }

    public void OnPointClicked()
    {
        isDropDownVisible = !isDropDownVisible;
        dropDown.SetActive(isDropDownVisible);

        // Show or hide the dropdown
        if (isDropDownVisible)
        {
            dropDownText.text = "Number of destinations remaining before the bonus round";
        }
    }

    void OnDropDownValueChanged(Dropdown dropdown)
    {
        // Hide the dropdown when a value is selected
        isDropDownVisible = false;
        dropDown.SetActive(isDropDownVisible);
    }
}