using System.Collections;
/*using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public GameObject nextCube; // Reference to the cube placed on top
    public Texture2D puzzlePart; // The part of the puzzle on the front side of this cube

    private bool isStacked = false;
    private bool isSelected = false;

    void Update()
    {
        // Check for cube selection using number keys (1, 2, 3, 4)
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "Cube1")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "Cube2")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "Cube3")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.name == "Cube4")
        {
            isSelected = !isSelected;
        }

        if (isSelected)
        {
            // Check for arrow key inputs and move the cube accordingly
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime);
        }

        // Check if this cube is stacked on top of the nextCube
        if (isStacked && Input.GetKeyDown(KeyCode.Space))
        {
            // Reveal the complete picture
            CombinePuzzle();
        }
    }

    void CombinePuzzle()
    {
        // Assuming you have a script on a separate GameObject holding the complete picture
        PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager != null)
        {
            // Apply the puzzle part to this cube
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.mainTexture = puzzlePart;
            }

            puzzleManager.CompletePuzzle();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if this cube is colliding with the nextCube
        if (collision.gameObject == nextCube)
        {
            isStacked = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if this cube is no longer colliding with the nextCube
        if (collision.gameObject == nextCube)
        {
            isStacked = false;
        }
    }
}*/

using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public GameObject nextCube; // Reference to the cube placed on top
    public Texture2D puzzlePart; // The part of the puzzle on the front side of this cube

    private bool isStacked = false;
    private bool isSelected = false;

    void Update()
    {
        // Check for cube selection using number keys (1, 2, 3, 4)
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "Cube1")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "Cube2")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "Cube3")
        {
            isSelected = !isSelected;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.name == "Cube4")
        {
            isSelected = !isSelected;
        }

        if (isSelected)
        {
            // Check for number pad inputs (8 for up, 2 for down, 6 for right, 4 for left)
            float verticalInput = 0f;
            float horizontalInput = 0f;

            if (Input.GetKey(KeyCode.Keypad8))
            {
                verticalInput = 1;
            }
            else if (Input.GetKey(KeyCode.Keypad2))
            {
                verticalInput = -1;
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                horizontalInput = 1;
            }
            else if (Input.GetKey(KeyCode.Keypad4))
            {
                horizontalInput = -1;
            }

            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime);
        }

        // Check if this cube is stacked on top of the nextCube
        if (isStacked && Input.GetKeyDown(KeyCode.Space))
        {
            // Reveal the complete picture
            CombinePuzzle();
        }
    }

    void CombinePuzzle()
    {
        // Assuming you have a script on a separate GameObject holding the complete picture
        PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager != null)
        {
            // Apply the puzzle part to this cube
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.mainTexture = puzzlePart;
            }

            puzzleManager.CompletePuzzle();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if this cube is colliding with the nextCube
        if (collision.gameObject == nextCube)
        {
            isStacked = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if this cube is no longer colliding with the nextCube
        if (collision.gameObject == nextCube)
        {
            isStacked = false;
        }
    }
}

