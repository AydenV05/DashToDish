using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Unity.VisualScripting;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;

    [SerializeField] GameObject TextPrefab;

    [SerializeField] GameObject listImage;

    private void Start()
    {
        TextPrefab.SetActive(false);
    }
    private void Update()
    {
        CheckCompletion();         
    }

    bool CheckCompletion()
    {
        int completionCount = 0;
        foreach(Items item in DataStore.Instance.shopListItems)
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
        Debug.Log("Collision Detected");
        if (CheckCompletion())
        {
            if (other.gameObject.tag == "Player")
            {
                DataStore.Instance.shopButtons.Add(Instantiate(buttonPrefab));
                DataStore.Instance.UnlockMouse();
                StartCoroutine(DelayInstantiation());
            }
        }
        if (!CheckCompletion())
        {
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        listImage.SetActive(false);
        TextPrefab.SetActive(true);
        yield return new WaitForSeconds(3);
        TextPrefab.SetActive(false);
        listImage.SetActive(true);
    }

    IEnumerator DelayInstantiation()
    {
        yield return new WaitForSeconds(3);
    }
}
