using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndSceneUI : MonoBehaviour
{
    private Dishes hsDish = DataStore.Instance.selectedDish;

    private Label score;
    private Label highScore;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button menuButton = root.Q<Button>("MenuButton");

        score= root.Q<Label>("ScoreLabel");
        highScore = root.Q<Label>("HSLabel");

        menuButton.clicked += MenuButton;

        PickHS();

        score.text ="Score: "+ DataStore.Instance.MinutesElapsed + ": " + DataStore.Instance.SecondsElapsed;
    }

    void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void PickHS()
    {
        switch (hsDish)
        {
            case Dishes.Spaghetti:
                highScore.text = "HighScore: "+ DataStore.Instance.HSSpaghetti;
                break;
            case Dishes.SteakFries:
                highScore.text = "HighScore: " + DataStore.Instance.HSSteakFries;
                break;
            case Dishes.TomatoSoup:
                highScore.text = "HighScore: " + DataStore.Instance.HSTomatoSoup;
                break;
        }
    }
}
