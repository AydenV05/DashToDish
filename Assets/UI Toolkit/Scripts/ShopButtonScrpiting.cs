using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopButtonScrpiting : MonoBehaviour
{
    [SerializeField] GameObject UIDoc;

    public GameObject shoplist=null;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        Button cancel=root.Q<Button>("ButtonCancel");
        Button purchase = root.Q<Button>("ButtonPurchase");


        cancel.clicked += () => CancelButton();
        purchase.clicked += () => PurchaseButton();
    }

    void CancelButton()
    {
        Debug.Log("Canceled!");
        DataStore.Instance.LockMouse();
        DestroyButtons();
    }

    void PurchaseButton()
    {
        DataStore.Instance.setMarkName = true;
        Debug.Log("Purchased!");
        DataStore.Instance.LockMouse();
        DestroyButtons();
        
    }


    void DestroyButtons()
    {
        foreach(var buttons in DataStore.Instance.shopButtons)
        {
            Destroy(buttons);
            DataStore.Instance.shopButtons.Remove(buttons);
        }
    }
}
