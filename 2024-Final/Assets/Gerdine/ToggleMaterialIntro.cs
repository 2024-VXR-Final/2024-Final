using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMaterialIntro : MonoBehaviour
{
    public Material stomachMaterial; // Reference to the stomach material
    public Material pancreasMaterial; // Reference to the pancreas material

    private Material originalMaterial; // Store the original material
    private bool stomachMaterialActive = false; // Track whether stomach material is active
    private bool pancreasMaterialActive = false; // Track whether pancreas material is active

    void Start()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Store the original material
        originalMaterial = renderer.material;
    }

    void Update()
    {
        // Check if 'S' key is pressed for stomach material toggle
        if (Input.GetKeyDown(KeyCode.S))
        {
            ToggleStomachMaterial();
        }

        // Check if 'P' key is pressed for pancreas material toggle
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePancreasMaterial();
        }
    }

    void ToggleStomachMaterial()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        if (!stomachMaterialActive)
        {
            // Assign the stomach material to the renderer
            renderer.material = stomachMaterial;

            stomachMaterialActive = true;
        }
        else
        {
            // Assign the original material to the renderer
            renderer.material = originalMaterial;

            stomachMaterialActive = false;
        }
    }

    void TogglePancreasMaterial()
    {
        // Get the renderer component attached to this GameObject
        Renderer renderer = GetComponent<Renderer>();

        if (!pancreasMaterialActive)
        {
            // Assign the pancreas material to the renderer
            renderer.material = pancreasMaterial;

            pancreasMaterialActive = true;
        }
        else
        {
            // Assign the original material to the renderer
            renderer.material = originalMaterial;

            pancreasMaterialActive = false;
        }
    }
}
