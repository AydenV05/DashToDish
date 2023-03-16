using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class Highscore
{
    public string name;
    public float time;
}

public class HighscoreManager : MonoBehaviour
{
    private List<Highscore> highscores = new List<Highscore>();

    Dishes dish = DataStore.Instance.selectedDish;

    private void Awake()
    {
        LoadHighscores();
    }

    public void AddHighscore(string name)
    {
        float time = PickHS(); // use PickHS() to get the time for this dish

        Highscore newHighscore = new Highscore();
        newHighscore.name = name;
        newHighscore.time = time;

        highscores.Add(newHighscore);
        SaveHighscores();
    }

    public List<Highscore> GetHighscores()
    {
        return highscores;
    }

    private void LoadHighscores()
    {
        string path = Application.persistentDataPath + "/highscores.dat";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            highscores = (List<Highscore>)bf.Deserialize(file);
            file.Close();
        }
    }

    private void SaveHighscores()
    {
        string path = Application.persistentDataPath + "/highscores.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, highscores);
        file.Close();
    }

    public float PickHS()
    {
        switch (dish)
        {
            case Dishes.Spaghetti: return DataStore.Instance.HSSpaghetti;
            case Dishes.SteakFries: return DataStore.Instance.HSSteakFries;
            case Dishes.TomatoSoup: return DataStore.Instance.HSTomatoSoup;
        }
        return 0;
    }
}


