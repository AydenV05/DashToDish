using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dishes
{
    Spaghetti,
    SteakFries,
    TomatoSoup,
    Fries,
    None
}

public class SetupList : MonoBehaviour
{
    [SerializeField] Dishes dish=Dishes.None;

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
            case Dishes.TomatoSoup: Ingreds = new List<string>() { "Tomato", "Carrot", "Water", "Beans" };
                break;
            case Dishes.Fries:Ingreds = new List<string>() { "Fries" };
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
