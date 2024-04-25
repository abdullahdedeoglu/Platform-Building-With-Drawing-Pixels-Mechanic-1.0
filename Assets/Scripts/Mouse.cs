using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject currentObject { get; private set;}

    private UniqueGrid uniqueGrid;

    private bool isDragging;

    private void Update()
    {
        MouseEvents();
    }

    private void MouseEvents()
    {
        // Left Click Events
        if (Input.GetMouseButtonDown(0)) // Dragging Check
        {
            isDragging = true; // Start Dragging

            UpdateCurrentObject();

            uniqueGrid.PaintGrid(true, isDragging); // isLeftClick Boolean Check
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; // Dragging Stop

            currentObject = null;
        }

        else if (Input.GetMouseButton(0) && isDragging) // Continue dragging and paint
        {
            UpdateCurrentObject();
            uniqueGrid.PaintGrid(true, isDragging);
        }

        // Right Click Events (I don't like the way i did, i'll update this later)

        if (Input.GetMouseButtonDown(1)) // Dragging Check
        {
            isDragging = true; // Start Dragging

            UpdateCurrentObject();

            uniqueGrid.PaintGrid(false, isDragging); // isLeftClick Boolean Check
        }

        else if (Input.GetMouseButtonUp(1))
        {
            isDragging = false; // Dragging Stop

            currentObject = null;
        }

        else if (Input.GetMouseButton(1) && isDragging) // Continue dragging and paint
        {
            UpdateCurrentObject();
            uniqueGrid.PaintGrid(false, isDragging);
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

            // Define UniqueGrid Component

            GetUniqueGrid();
        }
        else
        {
            currentObject = null;
        }
        
    }

    private void GetUniqueGrid() // Reach current grid's uniqueGrid Component
    {
        uniqueGrid = currentObject.GetComponent<UniqueGrid>();
    }
}
