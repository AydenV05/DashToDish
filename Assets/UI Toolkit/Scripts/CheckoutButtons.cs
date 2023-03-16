using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
        
        Invoke("LoadKitchen", 2);
        float waitingTime = Random.Range(5, 20);
        DataStore.Instance.SecondsElapsed += waitingTime;
        DestroyButtons();
        DataStore.Instance.LockMouse();
    }

    void SkipButton()
    {
        Invoke("LoadKitchen", 2);
        DataStore.Instance.SecondsElapsed += 12.5f;
        DestroyButtons();
        DataStore.Instance.LockMouse();
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
