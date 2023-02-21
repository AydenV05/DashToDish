using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dishes
{
    Spaghetti,
    SteakFries,
    None
}

public class SetupList : MonoBehaviour
{
    [SerializeField] Dishes dish=Dishes.Spaghetti;

    List<string> Ingreds = new List<string>();

    private void Update()
    {
        PickIngreds(dish); 
    }

    void PickIngreds(Dishes dish)
    {
        switch (dish)
        {
            case Dishes.Spaghetti: Ingreds = new List<string>() { "Tomato", "Beans", "Carrot", "Pasta" };
                break;
            case Dishes.SteakFries: Ingreds = new List<string>() { "Meat", "Fries" };
                break;
            case Dishes.None: Ingreds = new List<string>();
                break;
        }
        AddDataStoreIngreds();
    }

    void AddDataStoreIngreds()
    {
        DataStore.Instance.shoppingList.Clear();
        foreach(var item in Ingreds)
        {
            DataStore.Instance.shoppingList.Add(item);
        }
    }
}