using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .025f;
    private Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;

    [Header("Animations")]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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

        //The following keycodes are for the animator component (Specifically the walking anim)
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("Direction", 0);
        }
        animator.SetBool("IsMoving", moveDirection.magnitude > 0);
    }

    // Sets velocity to move the player
    void Move()
    {
        // Smooth velocity
        rb.velocity = Vector2.SmoothDamp(rb.velocity, moveDirection * moveSpeed, ref m_Velocity, m_MovementSmoothing);
    }

}
