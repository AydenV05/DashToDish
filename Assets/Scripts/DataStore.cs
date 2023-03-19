using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DataStore
{
    public List<string> shoppingList= new List<string>();

    public List<GameObject> shopButtons = new List<GameObject>();

    public List<GameObject> timeLabels= new List<GameObject>();

    public List<Items> shopListItems = new List<Items>();

    public List<Items> Inventory=new List<Items>();

    public bool setMarkName = false;

    public bool isMarking = false;

    public string markProduct = string.Empty;

    public float SecondsElapsed;

    public float MinutesElapsed;

    public bool itemNeedPickup = false;

    public string PickedUpItem = string.Empty;

    public Dishes selectedDish=Dishes.None;

    //HighScores
    public float HSSpaghetti;
    public float HSSteakFries;
    public float HSTomatoSoup;
    public float HSFries;

    
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StackTrace stackTrace = new StackTrace();
        StackFrame callingFrame = stackTrace.GetFrame(1);
        string callingScript = callingFrame.GetMethod().DeclaringType.Name;

        UnityEngine.Debug.Log($"LockMouse() called from {callingScript}");
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UnityEngine.Debug.Log("Mouse unlocked");
    }
    
    public static DataStore Instance
    {
        get
        {
            if (instance == null) instance = new DataStore();
            return instance;
        }
    }
    private static DataStore instance;
    private DataStore() { }
}
