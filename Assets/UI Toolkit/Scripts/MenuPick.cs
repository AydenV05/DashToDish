using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPick : MonoBehaviour
{
    private DropdownField dropdownField;

    private void OnEnable()
    {
        // Get the root VisualElement of the UI document
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // Find the DropdownField element by name
        DropdownField dropdownField = root.Q<DropdownField>("DishPick");

        // Get the list of dish names
        List<string> dishNames = Enum.GetNames(typeof(Dishes)).ToList();

        // Set the choices property of the DropdownField to the list of dish names
        dropdownField.choices = dishNames;

        // Subscribe to the OnSelection event of the DropdownField
        dropdownField.RegisterValueChangedCallback(OnSelection);

        Button continueButton = root.Q<Button>("Continue");

        continueButton.clicked += ContinueButton;

    }

    void OnSelection(ChangeEvent<string> e)
    {
        // Get the selected dish name
        string selectedValue = e.newValue;

        // Convert the selected value to a Dishes enum value
        Dishes selectedDish = (Dishes)Enum.Parse(typeof(Dishes), selectedValue);

        // Set the selected dish in the Datastore
        DataStore.Instance.selectedDish = selectedDish;

        // Do something else with the selected value if needed
        Debug.Log("Selected dish: " + selectedValue);
    }

    void ContinueButton()
    {
        if (DataStore.Instance.selectedDish != Dishes.None)
        {
            SceneManager.LoadScene("StoreScene");
        }
        
    }
}

