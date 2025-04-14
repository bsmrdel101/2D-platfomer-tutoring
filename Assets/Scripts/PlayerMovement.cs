using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 3f;
    private float horizontal;
    private Vector2 velocity;
    
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private Animator animator;
    

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Jump") && IsGrounded()) HandleJump();
    }

    private void FixedUpdate()
    {
        velocity = rb.velocity;
        HandleMovement();
        ApplyGravity();
        rb.velocity = velocity;
    }

    private void HandleMovement()
    {
        velocity.x = horizontal * moveSpeed;
        animator.SetBool("isRunning", horizontal != 0);
        if (horizontal < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        else if (horizontal > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
    }
    
    private void HandleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        Vector2 boxSize = new Vector2(0.8f, 0.3f);
        const float castDistance = 0.1f;
        RaycastHit2D hit = Physics2D.BoxCast(groundCheckTransform.position, boxSize, 0f, Vector2.down, castDistance, LayerMask.GetMask("Ground"));
        return hit.collider is not null;
    }

    private void ApplyGravity()
    {
        if (velocity.y <= 4.5f)
            velocity += Vector2.up * (Physics2D.gravity.y * fallMultiplier * Time.fixedDeltaTime);
        else if (velocity.y > 0 && !Input.GetButton("Jump"))
            velocity += Vector2.up * (Physics2D.gravity.y * lowJumpMultiplier * Time.fixedDeltaTime);
    }
}
