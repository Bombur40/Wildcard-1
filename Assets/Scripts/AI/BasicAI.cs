using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private Rigidbody2D rb;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .025f;
    private Vector2 moveDirection;
    private Vector2 m_Velocity = Vector2.zero;
    public float speed;
    private void Update()
    {
        Move();
    }

    void Move() {
        float targetX = target.position.x;
        float targetY = target.position.y;
        moveDirection = new Vector2(targetX - transform.position.x, targetY - transform.position.y).normalized;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, moveDirection * speed, ref m_Velocity, m_MovementSmoothing);
    }
}
