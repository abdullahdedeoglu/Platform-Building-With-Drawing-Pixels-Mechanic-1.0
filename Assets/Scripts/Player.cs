using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 3f;
    private float moveHorizontal;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        // Get Axis Inputs
        moveHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        if(moveHorizontal >0.1f || moveHorizontal < 0.1f)
        {
            rb.AddForce(new Vector2 (moveHorizontal * moveSpeed * Time.deltaTime, 0f), ForceMode2D.Impulse);
        }
    }
}
