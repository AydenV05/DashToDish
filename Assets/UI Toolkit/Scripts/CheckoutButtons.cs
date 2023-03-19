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
        float waitingTime = Random.Range(5, 20);
        DataStore.Instance.SecondsElapsed += waitingTime;
        DataStore.Instance.LockMouse();
        SceneManager.LoadScene("KitchenScene");
        DestroyButtons();
    }

    void SkipButton()
    {
        DataStore.Instance.SecondsElapsed += 12.5f;
        DataStore.Instance.LockMouse();
        SceneManager.LoadScene("KitchenScene");
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
