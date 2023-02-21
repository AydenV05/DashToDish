using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // The texture to use for the crosshair
    public Texture2D crosshairTexture;

    // The size of the crosshair
    public int crosshairSize = 32;

    // The position of the crosshair
    private Rect crosshairPosition;

    void Start()
    {
        // Calculate the position of the crosshair
        crosshairPosition = new Rect((Screen.width - crosshairSize) / 2,
                                     (Screen.height - crosshairSize) / 2,
                                     crosshairSize, crosshairSize);
    }

    void OnGUI()
    {
        // Draw the crosshair on the screen
        GUI.DrawTexture(crosshairPosition, crosshairTexture);
    }
}
