using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    List<Items> Inventory = new List<Items> { };
    
    
    private void Update()
    {
        PickupItem();
        DataStore.Instance.Inventory = Inventory;
    }

    void PickupItem()
    {
        if (DataStore.Instance.itemNeedPickup)
        {
            for(int i = 0; i < DataStore.Instance.shopListItems.Count; i++)
            {
                if (!DataStore.Instance.shopListItems[i].isPickedUp)
                {
                    Items item = DataStore.Instance.shopListItems[i];
                    Debug.Log(item.ToString());
                    Inventory.Add(item);
                    DataStore.Instance.shopListItems[i].isPickedUp = true;
                    Debug.Log(item.ToString());

                    DataStore.Instance.itemNeedPickup = false;
                    break;
                }
            }
            
        }
    }


}
