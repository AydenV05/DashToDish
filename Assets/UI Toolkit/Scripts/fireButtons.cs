using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class fireButtons : MonoBehaviour
{
    [SerializeField] GameObject timerLabel;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button cookButton = root.Q<Button>("CookButton");
        Button cancelButton = root.Q<Button>("CancelButton");

        cookButton.clicked += CookButton;
        cancelButton.clicked += CancelButton;
    }

    void CookButton()
    {
        DataStore.Instance.timeLabels.Add(Instantiate(timerLabel));
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
