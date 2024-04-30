using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player

    [SerializeField] private float moveSpeed = 3f; // Speed at which the player moves
    private float moveHorizontal; // Horizontal input from the player

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    private void Update()
    {
        GetInput(); // Get player input
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Move the player based on input
    }

    private void GetInput()
    {
        // Get horizontal axis input
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        // Move the player horizontally based on input
        if (Mathf.Abs(moveHorizontal) > 0.1f)
        {
            // Apply force to the player in the horizontal direction
            rb.AddForce(new Vector2(moveHorizontal * moveSpeed * Time.deltaTime, 0f), ForceMode2D.Impulse);
        }
    }
}
