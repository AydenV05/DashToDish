using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore
{
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
