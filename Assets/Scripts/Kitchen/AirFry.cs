using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFry : MonoBehaviour
{
    [SerializeField] GameObject AirFryText;

    [SerializeField] GameObject AirFryButtons;

    private void OnTriggerEnter(Collider other)
    {
        if (DataStore.Instance.Inventory.Count == 0)
        {
            Instantiate(AirFryText);
        }
        else if (DataStore.Instance.Inventory[0].ProductName=="Fries")
        {
            DataStore.Instance.shopButtons.Add(Instantiate(AirFryButtons));
            DataStore.Instance.UnlockMouse();
        }
        else
        {
            Instantiate(AirFryText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DestroyButtons();
    }

    void DestroyButtons()
    {
        foreach (var buttons in DataStore.Instance.shopButtons)
        {
            Destroy(buttons);
            DataStore.Instance.shopButtons.Remove(buttons);
        }
    }
}
