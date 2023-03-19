using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void OnEnable()
    {
        DataStore.Instance.UnlockMouse();
        
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button homeButton = root.Q<Button>("HomeButton");
        Button resumeButton = root.Q<Button>("ResumeButton");

        homeButton.clicked += HomeButton;
        resumeButton.clicked += ResumeButton;

    }

    void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ResumeButton()
    {
        Time.timeScale = 1;
        DataStore.Instance.LockMouse();
        menu.SetActive(false);
        
    }
}
