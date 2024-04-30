using UnityEngine;

public class GridMaker : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab; // Prefab for grid cells
    [SerializeField] private float gridSize = 32; // Size of the grid (number of cells)
    [SerializeField] private float distance = 0.28f; // Distance between grid cells
    [SerializeField] private SceneScriptableObject sceneSO; // ScriptableObject containing scene data

    private Vector3 startingPosition; // Starting position for grid creation

    private void Start()
    {
        startingPosition = transform.position; // Store the starting position
        CreateGrid(); // Create the grid
    }

    private void CreateGrid()
    {
        int orderCount = 0; // Initialize order count for grid cells

        // Loop through rows and columns to create grid cells
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                // Create a new grid cell
                GameObject grid = Instantiate(gridPrefab, transform);
                // Position the grid cell based on grid size and distance between cells
                grid.transform.position = new Vector3(startingPosition.x + i * distance, startingPosition.y - j * distance, 0);

                // Get the UniqueGrid component attached to the grid cell
                UniqueGrid currentUniqueGrid = grid.GetComponent<UniqueGrid>();

                // Calculate the index of the sprite in the sceneSO.sceneSprites array
                int spriteIndex = j * (int)gridSize + i;

                // Check if the sprite index is within the bounds of the sceneSO.sceneSprites array
                if (spriteIndex < sceneSO.sceneSprites.Length)
                {
                    // Assign the sprite to the grid cell
                    currentUniqueGrid.sprites[0] = sceneSO.sceneSprites[spriteIndex];
                }
                else
                {
                    // Log an error if there are not enough sprites in the sceneSO.sceneSprites array
                    Debug.LogError("Not enough sprites in sceneSO.sceneSprites array.");
                }

                // Write the order number of the grid cell (will be deleted in final version)
                currentUniqueGrid.WriteOrderNumber(orderCount);

                // Check if the current grid cell should have a collider based on order count
                if (sceneSO.collisionGridList.Contains(orderCount))
                {
                    // Activate the box collider of the grid cell
                    currentUniqueGrid.ActivateBoxCollider();
                }

                // Increment the order count for the next grid cell
                orderCount++;
            }
        }
    }
}
