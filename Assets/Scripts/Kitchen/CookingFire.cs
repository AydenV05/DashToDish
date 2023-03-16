using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingFire : MonoBehaviour
{
    [SerializeField] GameObject CookText;

    [SerializeField] GameObject CookButtons;

    private void OnTriggerEnter(Collider other)
    {
        if (DataStore.Instance.Inventory.Count == 0)
        {
            Instantiate(CookText);
        }
        else if (DataStore.Instance.Inventory[0].ProductName != "Fries")
        {
            DataStore.Instance.shopButtons.Add(Instantiate(CookButtons));
            DataStore.Instance.UnlockMouse();
        }
        else
        {
            Instantiate(CookText);
        }
    }
}
