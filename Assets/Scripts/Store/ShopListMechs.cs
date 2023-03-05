using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class ShopListMechs : MonoBehaviour
{
    public List<Items> itemLijst = new List<Items>();

    public float itemSpacing = 20f; // The spacing between items
    public float nameOffset = 50f; // The offset of the name from the left edge of the screen
    public float imageOffset = 100f; // The offset of the image from the left edge of the screen

    string markProductName = DataStore.Instance.markProduct;

    bool listIsMade = false;



    private void Update()
    {
        markProductName = DataStore.Instance.markProduct;
        MarkOffItem(markProductName);
    }
    
    void MakeList()
    {
        foreach(var name in DataStore.Instance.shoppingList)
        {
            Items item = new Items(name);
            itemLijst.Add(item);
        }
        DataStore.Instance.shopListItems = itemLijst;
    }

    void OnGUI()
    {
        /*float y = 0f;
        foreach(Items item in itemLijst)
        {
            // Draw the item name
            GUI.color = item.isCheckedOff ? Color.green : Color.white; // Set color to green if item is marked off
            GUI.Label(new Rect(nameOffset, y, 200f, 20f), item.ProductName);


            // Draw the item image
            if (item.Foto != null)
            {
                GUI.DrawTexture(new Rect(imageOffset, y, 64, 64), item.Foto);
            }
            

            y += itemSpacing;
        }*/
        if (!listIsMade)
        {
            MakeList();
            listIsMade = true;
        }
        
        DrawStuff();
    }

    void DrawStuff()
    {
        float y = 65f;
        foreach (Items item in itemLijst)
        {
            // Draw the item name
            GUI.depth = 1; // set depth to ensure text is always rendered on top
            GUI.color = item.isCheckedOff ? Color.green : Color.black; // Set color to green if item is marked off
            GUI.Label(new Rect(nameOffset, y, 200f, 20f), item.ProductName);


            // Draw the item image
            if (item.Foto != null)
            {
                GUI.DrawTexture(new Rect(imageOffset, y, 64, 64), item.Foto);
            }


            y += itemSpacing;
        }
        //Debug.Log("GUI Done");
    }

    public void MarkOffItem(string itemName)
    {
        if (DataStore.Instance.isMarking)
        {
            foreach (Items item in itemLijst)
            {
                if (item.ProductName == itemName)
                {
                    item.isCheckedOff = true;
                    break;
                }
            }
            DataStore.Instance.isMarking = false;
        }
        DrawStuff();
    }
}
