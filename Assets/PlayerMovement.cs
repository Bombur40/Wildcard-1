using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public int dashSpeed;
    public int dashDuration;
    public int dashCooldown;
    private int dashCount = 0;

    private Vector2 moveDirection;
    private Vector2 dashDirection;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // This update is called on a consistent fixed time which makes it better to put our move function
    void FixedUpdate()
    {
        //ProcessInputs();
    }
    
    // Gets inputs and processes the inputs into movements
    void ProcessInputs()
    {
        if (dashCount > 0) {
            dashCount--;
            Dash();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)){
            dashCount = dashDuration;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dashDirection = new Vector2(mousePos.x - rb.position.x, mousePos.y - rb.position.y).normalized;
        }
        else {
            //GetAxis will get the inputs from Unity's default inputs
            //horizantal: a, d, left arrow, right arrow
            //vertical: w, s, up arrow, down arrow
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            //makes a vector for the movement, and normalizes it so moving diagonally won't be extra fast
            moveDirection = new Vector2(moveX, moveY).normalized;
            Move();
        }
    }

    // Sets velocity to vector moveDirection to move the player
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Dash()
    {
        rb.velocity = new Vector2(dashDirection.x * dashSpeed, dashDirection.y * dashSpeed);
    }

}
