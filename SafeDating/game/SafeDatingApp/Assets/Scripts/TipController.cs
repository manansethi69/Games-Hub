using UnityEngine;

public class TipController : MonoBehaviour
{
    public GameObject MoneyDescription;
    public GameObject LocationDescription;
    public GameObject moneyObject;
    public GameObject locationObject;

    void Start()
    {
        if (moneyObject != null)
        {
            moneyObject.SetActive(false);
        }

        if (locationObject != null)
        {
            locationObject.SetActive(false);
        }

        if (MoneyDescription != null)
        {
            MoneyDescription.SetActive(false);
        }

        if (LocationDescription != null)
        {
            LocationDescription.SetActive(false);
        }
    }

    public void ToggleMoneyDescription()
    {
        if (MoneyDescription != null)
        {
            MoneyDescription.SetActive(!MoneyDescription.activeSelf);

            if (moneyObject != null)
            {
                moneyObject.SetActive(MoneyDescription.activeSelf);
            }

            if (MoneyDescription.activeSelf && LocationDescription != null)
            {
                LocationDescription.SetActive(false);
                if (locationObject != null)
                {
                    locationObject.SetActive(false);
                }
            }
        }
    }

    public void ToggleLocationDescription()
    {
        if (LocationDescription != null)
        {
            LocationDescription.SetActive(!LocationDescription.activeSelf);

            if (locationObject != null)
            {
                locationObject.SetActive(LocationDescription.activeSelf);
            }

            if (LocationDescription.activeSelf && MoneyDescription != null)
            {
                MoneyDescription.SetActive(false);
                if (moneyObject != null)
                {
                    moneyObject.SetActive(false);
                }
            }
        }
    }
}