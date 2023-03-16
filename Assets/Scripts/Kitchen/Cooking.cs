using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            for (int i = 0; i < DataStore.Instance.shopListItems.Count; i++)
            {
                if (!CheckPickup(i) && !CheckCheckOff(i))
                {
                    Items item = DataStore.Instance.shopListItems[i];
                    Debug.Log(item.ToString());
                    Inventory.Add(item);
                    DataStore.Instance.shopListItems[i].isPickedUp = true;
                    DataStore.Instance.PickedUpItem=DataStore.Instance.shopListItems[i].ProductName;
                    Debug.Log(item.ToString());

                    DataStore.Instance.itemNeedPickup = false;
                    break;
                }
            }

        }
    }

    bool CheckPickup(int index)
    {
        if (DataStore.Instance.shopListItems[index].isPickedUp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckCheckOff(int index)
    {
        if (DataStore.Instance.shopListItems[index].isCheckedOff)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    
}
