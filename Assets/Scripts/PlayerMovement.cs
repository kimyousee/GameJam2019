using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    float moveSpeed = 10f;

    public Vector2 mousePointWorld;

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;
    }
    
    void FixedUpdate()
    {
        // Move the player based on their input
        Vector2 movementVector = new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + movementVector);

        // Rotate the player based on their mouse position
        mousePointWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePointWorld.x - transform.position.x, mousePointWorld.y - transform.position.y);
        transform.up = direction;
    }
}
