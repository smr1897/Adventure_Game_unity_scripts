using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Texture2D completePicture; // Reference to the complete picture

    public void CompletePuzzle()
    {
        // Apply the complete picture to a UI image or another GameObject
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = completePicture;
        }

        // Add any additional logic for completing the puzzle
    }
}



