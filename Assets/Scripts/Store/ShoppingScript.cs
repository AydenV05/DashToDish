using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MarkName
{
    Tomato,
    Fries,
    Milk,
    Carrot,
    Pasta,
    Beans,
    Cookie,
    Snoep,
    Water,
    Coke,
    Fish,
    Meat,
    Peas,
    Beer,
    Chicken,
    None
}

public class ShoppingScript : MonoBehaviour
{
    [SerializeField] GameObject buttonsPrefab;

    [SerializeField] MarkName markname = MarkName.None;

    [SerializeField] GameObject display;

    bool colliderIsTriggered = false;

    Renderer displayRenderer;

    [SerializeField] Material matTomato;
    [SerializeField] Material matFries;
    [SerializeField] Material matMilk;
    [SerializeField] Material matCarrot;
    [SerializeField] Material matPasta;
    [SerializeField] Material matBeans;
    [SerializeField] Material matCookie;
    [SerializeField] Material matSnoep;
    [SerializeField] Material matWater;
    [SerializeField] Material matCoke;
    [SerializeField] Material matFish;
    [SerializeField] Material matMeat;
    [SerializeField] Material matPeas;
    [SerializeField] Material matBeer;
    [SerializeField] Material matChicken;
    [SerializeField] Material matNone;

    private void Start()
    {
        displayRenderer = display.GetComponent<Renderer>();
        PickPicture();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!colliderIsTriggered)
            {
                if (DataStore.Instance.shopButtons.Count == 0)
                {
                    GameObject buttons = Instantiate(buttonsPrefab);
                    DataStore.Instance.shopButtons.Add(buttons);
                    DataStore.Instance.UnlockMouse();

                    colliderIsTriggered = true;
                }
            }
             
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliderIsTriggered = false;
        DestroyButtons();
    }

    private void Update()
    {
        SetMarkName();
    }


    void SetMarkName()
    {
        if (DataStore.Instance.setMarkName && colliderIsTriggered)
        {
            switch (markname)
            {
                case MarkName.Tomato:
                    DataStore.Instance.markProduct = "Tomato";
                    break;
                case MarkName.Fries:
                    DataStore.Instance.markProduct = "Fries";
                    break;
                case MarkName.Milk:
                    DataStore.Instance.markProduct = "Milk";
                    break;
                case MarkName.Carrot:
                    DataStore.Instance.markProduct = "Carrot";
                    break;
                case MarkName.Pasta:
                    DataStore.Instance.markProduct = "Pasta";
                    break;
                case MarkName.Beans:
                    DataStore.Instance.markProduct = "Beans";
                    break;
                case MarkName.Cookie:
                    DataStore.Instance.markProduct = "Cookie";
                    break;
                case MarkName.Snoep:
                    DataStore.Instance.markProduct = "Candy";
                    break;
                case MarkName.Water:
                    DataStore.Instance.markProduct = "Water";
                    break;
                case MarkName.Coke:
                    DataStore.Instance.markProduct = "Coke";
                    break;
                case MarkName.Fish:
                    DataStore.Instance.markProduct = "Fish";
                    break;
                case MarkName.Meat:
                    DataStore.Instance.markProduct = "Meat";
                    break;
                case MarkName.Peas:
                    DataStore.Instance.markProduct = "Peas";
                    break;
                case MarkName.Beer:
                    DataStore.Instance.markProduct = "Beer";
                    break;
                case MarkName.Chicken:
                    DataStore.Instance.markProduct = "Chicken";
                    break;

            }
            Debug.Log("markProduct set to:" + DataStore.Instance.markProduct);
            DataStore.Instance.setMarkName = false;
            DataStore.Instance.isMarking = true;
        }
    }

    void PickPicture()
    {
        switch (markname)
        {
            case MarkName.Tomato:
                displayRenderer.material = matTomato;
                break;
            case MarkName.Fries:
                displayRenderer.material = matFries;
                break;
            case MarkName.Milk:
                displayRenderer.material = matMilk;
                break;
            case MarkName.Carrot:
                displayRenderer.material = matCarrot;
                break;
            case MarkName.Pasta:
                displayRenderer.material = matPasta;
                break;
            case MarkName.Beans:
                displayRenderer.material = matBeans;
                break;
            case MarkName.Cookie:
                displayRenderer.material = matCookie;
                break;
            case MarkName.Snoep:
                displayRenderer.material = matSnoep;
                break;
            case MarkName.Water:
                displayRenderer.material = matWater;
                break;
            case MarkName.Coke:
                displayRenderer.material = matCoke;
                break;
            case MarkName.Fish:
                displayRenderer.material = matFish;
                break;
            case MarkName.Meat:
                displayRenderer.material = matMeat;
                break;
            case MarkName.Peas:
                displayRenderer.material = matPeas;
                break;
            case MarkName.Beer:
                displayRenderer.material = matBeer;
                break;
            case MarkName.Chicken:
                displayRenderer.material = matChicken;
                break;
        }
    }

    void DestroyButtons()
    {
        foreach (var buttons in DataStore.Instance.shopButtons)
        {
            Destroy(buttons);
            DataStore.Instance.shopButtons.Remove(buttons);
        }
    }
}


