using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreEndScene : MonoBehaviour
{
    private Dishes hsDish = DataStore.Instance.selectedDish;

    float newScore = 0;

    string selectDish = string.Empty;

    float originalScore;

    bool scoreIsUpdated = false;

    private void Start()
    {
        newScore = DataStore.Instance.MinutesElapsed * 60 + DataStore.Instance.SecondsElapsed;
    }

    private void Update()
    {
        if (!scoreIsUpdated)
        {
            PickHS();            
            if(selectDish != string.Empty)
            {
                if (selectDish == "Spaghetti")
                {
                    DataStore.Instance.HSSpaghetti = CheckHigherOrLower(originalScore, newScore);
                }
                if (selectDish == "SteakFries")
                {
                    DataStore.Instance.HSSteakFries = CheckHigherOrLower(originalScore, newScore);
                }
                if (selectDish == "TomatoSoup")
                {
                    DataStore.Instance.HSTomatoSoup = CheckHigherOrLower(originalScore, newScore);
                }
            }
            scoreIsUpdated = true;
        }
    }



    void PickHS()
    {
        switch (hsDish)
        {
            case Dishes.Spaghetti:
                selectDish = "Spaghetti";
                originalScore = DataStore.Instance.HSSpaghetti;
                break;
            case Dishes.SteakFries:
                originalScore = DataStore.Instance.HSSteakFries;
                selectDish = "SteakFries";
                break;
            case Dishes.TomatoSoup:
                originalScore = DataStore.Instance.HSTomatoSoup;
                selectDish = "TomatoSoup";
                break;
        }
    }


    float CheckHigherOrLower(float originalScore, float newScore)
    {
        if(originalScore < newScore) { return originalScore; }
        if(newScore < originalScore) { return newScore; }
        return originalScore;
    }
}
