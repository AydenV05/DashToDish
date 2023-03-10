using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerController : MonoBehaviour
{
    [SerializeField] float countdownTime;
    Label countdownLabel;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        countdownLabel = root.Q<Label>("CookTimeLabel");
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownLabel.text = "Remaining wait time: "+ countdownTime.ToString("F1");
            yield return new WaitForSeconds(0.1f);
            countdownTime -= 0.1f;
        }
        countdownLabel.text = "Fries are done!";
        MarkOff(DataStore.Instance.Inventory[0].ProductName);
    }

    void MarkOff(string itemname)
    {
        foreach(Items items in DataStore.Instance.shopListItems)
        {
            if (items.ProductName == itemname)
            {
                items.isCheckedOff = true;
                items.isPickedUp = false;
            }
        }
    }

}
