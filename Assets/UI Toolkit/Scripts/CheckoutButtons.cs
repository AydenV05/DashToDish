using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CheckoutButtons : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button checkout = root.Q<Button>("ButtonCheckout");
        Button skip = root.Q<Button>("ButtonSkipCheckout");

        checkout.clicked += () => CheckoutButton();
        skip.clicked += () => SkipButton();
    }

    void CheckoutButton()
    {
        Invoke("LoadKitchen", 3);
        float waitingTime = Random.Range(5, 20);
        DataStore.Instance.ElapsedTime += waitingTime;
        DestroyButtons();
    }

    void SkipButton()
    {
        Invoke("LoadKitchen", 3);
        DataStore.Instance.ElapsedTime += 12.5f;
        DestroyButtons();
    }

    void LoadKitchen()
    {
        SceneManager.LoadScene("KitchenScene");
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
