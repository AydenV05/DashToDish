using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerScript : MonoBehaviour
{
    private Label timerLabel;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        timerLabel = root.Q<Label>("TimerLabel");
    }

    private void Update()
    {
        DataStore.Instance.SecondsElapsed += Time.deltaTime;

        FixMinutes();

        // Update the timer label with the ToString() method
        timerLabel.text = ToString();
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    public override string ToString()
    {
        return "Time: " + DataStore.Instance.MinutesElapsed + ":" + Round(DataStore.Instance.SecondsElapsed, 2).ToString("F2");
    }


    void FixMinutes()
    {
        if (DataStore.Instance.SecondsElapsed > 60)
        {
            DataStore.Instance.SecondsElapsed -= 60;
            DataStore.Instance.MinutesElapsed++;
        }
    }
}
