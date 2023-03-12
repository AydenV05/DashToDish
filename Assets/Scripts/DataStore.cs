using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore
{
    public List<string> shoppingList= new List<string>();

    public List<GameObject> shopButtons = new List<GameObject>();

    public List<Items> shopListItems = new List<Items>();

    public List<Items> Inventory=new List<Items>();

    public bool setMarkName = false;

    public bool isMarking = false;

    public string markProduct = string.Empty;

    public float ElapsedTime;

    public bool itemNeedPickup = false;

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
