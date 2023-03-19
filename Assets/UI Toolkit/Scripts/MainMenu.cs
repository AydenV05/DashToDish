using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        DataStore.Instance.UnlockMouse();
    }
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button playbutton = root.Q<Button>("PlayButton");

        playbutton.clicked += PLayButton;
    }

    void PLayButton()
    {
        SceneManager.LoadScene("DishPickScene");
        DataStore.Instance.SecondsElapsed = 0;
        DataStore.Instance.MinutesElapsed = 0;
    }
}
