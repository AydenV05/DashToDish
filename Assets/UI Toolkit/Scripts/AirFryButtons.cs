using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AirFryButtons : MonoBehaviour
{
    [SerializeField] GameObject timerLabel;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button fryButton = root.Q<Button>("FryButton");
        Button cancelButton = root.Q<Button>("CancelButton");

        fryButton.clicked += FryButton;
        cancelButton.clicked+=CancelButton;
    }

    void FryButton()
    {
        Instantiate(timerLabel);
        DataStore.Instance.LockMouse();
        DestroyButtons();
    }

    void CancelButton()
    {
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
}
