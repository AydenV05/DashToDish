using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] GameObject buttonUIDoc;

    private void OnTriggerEnter(Collider other)
    {
        if (DataStore.Instance.shopButtons.Count == 0)
        {
            GameObject button = Instantiate(buttonUIDoc);
            DataStore.Instance.shopButtons.Add(button);
        }
        else
        {
            DestroyButtons();
            GameObject button = Instantiate(buttonUIDoc);
            DataStore.Instance.shopButtons.Add(button);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        DataStore.Instance.LockMouse();
    }

    void DestroyButtons()
    {
        foreach (var buttons in DataStore.Instance.shopButtons)
        {
            Destroy(buttons);
            DataStore.Instance.shopButtons.Remove(buttons);
            DataStore.Instance.LockMouse();
        }
    }
}
