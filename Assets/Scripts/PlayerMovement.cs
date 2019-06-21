using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    float moveSpeed = 10f;

    Vector2 mousePos;

    public Vector2 mousePointWorld;

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
    }
    
    void FixedUpdate()
    {
        // Move the player based on their input
        Vector2 movementVector = new Vector2(horizontalMove, verticalMove) * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + movementVector);

        // Rotate the player based on their mouse position
        mousePointWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        // Convert mouse position from world to local space. Normalize it
        Vector3 mousePointLocal = transform.InverseTransformPoint(mousePointWorld);
        mousePointLocal.z = 0;
        transform.Rotate(0,0,Vector3.Angle(transform.forward, mousePointLocal.normalized));

    }
}
