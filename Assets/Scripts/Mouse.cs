using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject currentObject { get; private set; }

    private UniqueGrid uniqueGrid;
    private bool isDragging;

    private void Update()
    {
        MouseEvents(); // Call method to handle mouse events
    }

    private void MouseEvents()
    {
        // Left Click Events
        if (Input.GetMouseButtonDown(0)) // Left mouse button down
        {
            isDragging = true; // Start dragging
            UpdateCurrentObject(); // Update the current object under the mouse
            PaintGrid(true); // Paint grid with left click
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button up
        {
            isDragging = false; // Stop dragging
            currentObject = null; // Reset current object
        }
        else if (Input.GetMouseButton(0) && isDragging) // Left mouse button held down
        {
            UpdateCurrentObject(); // Update the current object under the mouse
            PaintGrid(true); // Paint grid with left click
        }

        // Right Click Events
        if (Input.GetMouseButtonDown(1)) // Right mouse button down
        {
            isDragging = true; // Start dragging
            UpdateCurrentObject(); // Update the current object under the mouse
            PaintGrid(false); // Paint grid with right click
        }
        else if (Input.GetMouseButtonUp(1)) // Right mouse button up
        {
            isDragging = false; // Stop dragging
            currentObject = null; // Reset current object
        }
        else if (Input.GetMouseButton(1) && isDragging) // Right mouse button held down
        {
            UpdateCurrentObject(); // Update the current object under the mouse
            PaintGrid(false); // Paint grid with right click
        }
    }

    private void UpdateCurrentObject()
    {
        // Cast a ray to the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Get the grid from ray
        if (hit.collider != null)
        {
            currentObject = hit.collider.gameObject;
            GetUniqueGrid(); // Retrieve UniqueGrid component
        }
        else
        {
            currentObject = null;
        }
    }

    private void GetUniqueGrid()
    {
        uniqueGrid = currentObject.GetComponent<UniqueGrid>(); // Get UniqueGrid component from current object
    }

    private void PaintGrid(bool isLeftClick)
    {
        if (uniqueGrid != null)
        {
            uniqueGrid.PaintGrid(isLeftClick, isDragging); // Paint grid based on left or right click
        }
    }
}
