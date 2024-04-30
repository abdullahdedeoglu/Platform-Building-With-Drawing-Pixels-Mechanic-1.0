using UnityEngine;

public class UniqueGrid : MonoBehaviour
{
    // Variables to track mouse interaction and store components
    private bool mouseOnSquare;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Array of sprites to use for painting the grid
    public Sprite[] sprites;

    // Serialized field for order number
    [SerializeField] private int orderNumber;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get references to the SpriteRenderer and BoxCollider2D components
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Set the initial sprite if sprites array is not empty
        if (sprites.Length > 0)
            spriteRenderer.sprite = sprites[0];
    }

    // Method to handle painting the grid based on mouse input
    public void PaintGrid(bool isLeftClick, bool isDragging)
    {
        if (mouseOnSquare)
        {
            // Paint the grid if left-clicking and dragging
            if (isLeftClick && isDragging && spriteRenderer.sprite != sprites[1])
            {
                spriteRenderer.sprite = sprites[1];
                ActivateBoxCollider();
            }
            // Clear the paint if right-clicking and dragging
            else if (!isLeftClick && isDragging && spriteRenderer.sprite != sprites[0])
            {
                DeactivateBoxCollider();
                spriteRenderer.sprite = sprites[0];
            }
        }
    }

    // Method to activate the box collider
    public void ActivateBoxCollider()
    {
        boxCollider.isTrigger = false;
    }

    // Method to deactivate the box collider
    public void DeactivateBoxCollider()
    {
        boxCollider.isTrigger = true;
    }

    // Called when the mouse enters the collider of the GameObject
    private void OnMouseEnter()
    {
        mouseOnSquare = true;
    }

    // Called when the mouse exits the collider of the GameObject
    private void OnMouseExit()
    {
        mouseOnSquare = false;
    }

    // Method to write the order number
    public void WriteOrderNumber(int orderIndex)
    {
        orderNumber = orderIndex;
    }
}
