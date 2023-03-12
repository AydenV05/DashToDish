using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImagePick
{
    ShopList,
    Recipe,
    None
}
public class ShoppingList : MonoBehaviour
{
    [SerializeField] ImagePick imagePicker=ImagePick.None;

    [SerializeField] Sprite shopList;
    [SerializeField] Sprite recipeList;

    Sprite sprite; // The sprite to render
    public Rect rect; // The rect of the sprite
    public float xOffset = -50f; // The x offset from the right edge of the screen
    public float yOffset = 50f; // The y offset from the top edge of the screen
    private void Start()
    {
        PickImage(imagePicker);
    }
    void OnGUI()
    {
        // Calculate the position of the sprite based on the screen size and offsets
        float x = Screen.width + xOffset - rect.width;
        float y = yOffset;

        // Draw the sprite at the calculated position and rect
        GUI.depth = 5;
        GUI.DrawTexture(rect, sprite.texture);
    }

    // Function to set the rect of the sprite
    public void SetRect(Rect newRect)
    {
        rect = newRect;
    }

    void PickImage(ImagePick image)
    {
        switch (image)
        {
            case ImagePick.ShopList: sprite = shopList; break;

            case ImagePick.Recipe: sprite = recipeList; break;
        }
    }
}
