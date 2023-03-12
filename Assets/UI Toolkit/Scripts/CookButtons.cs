using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CookButtons : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button newItemButton= root.Q<Button>("ItemButton"); Debug.Log("newItemButton initiated");
        Button cancelButton = root.Q<Button>("CancelButton"); Debug.Log("cancelButton initiated");

        cancelButton.clicked += CancelButton;
        newItemButton.clicked += ItemButton;

        DataStore.Instance.UnlockMouse();

    }

    void CancelButton()
    {
        Debug.Log("CancelButton Pressed.");

        DestroyButtons();
        DataStore.Instance.LockMouse();
    }

    void ItemButton()
    {
        Debug.Log("ItemButton Pressed");
        PrintItems();        
        
        DataStore.Instance.itemNeedPickup = true;
        PrintItems();

        DataStore.Instance.LockMouse();
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

    void PrintItems()
    {
        foreach(Items item in DataStore.Instance.shopListItems)
        {
            Debug.Log(item.ToString());
        }
    }
}
