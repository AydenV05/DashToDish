using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{
    private void Update()
    {
        CheckCompletion();
    }

    bool CheckCompletion()
    {
        int completionCount = 0;
        foreach (Items item in DataStore.Instance.shopListItems)
        {
            if (item.isCheckedOff)
            {
                completionCount++;

            }
        }

        if (completionCount == DataStore.Instance.shoppingList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckCompletion())
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
