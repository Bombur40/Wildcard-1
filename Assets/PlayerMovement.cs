using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .025f;
    private Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    // This update is called on a consistent fixed time which makes it better to put our move function
    void FixedUpdate()
    {
        Move();
    }
    
    // Gets inputs and processes the inputs into movements
    void ProcessInputs()
    {
        //GetAxis will get the inputs from Unity's default inputs
        //horizantal: a, d, left arrow, right arrow
        //vertical: w, s, up arrow, down arrow
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //makes a vector for the movement, and normalizes it so moving diagonally won't be extra fast
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    // Sets velocity to move the player
    void Move()
    {
        // Smooth velocity
        rb.velocity = Vector2.SmoothDamp(rb.velocity, moveDirection * moveSpeed, ref m_Velocity, m_MovementSmoothing);
    }

}
