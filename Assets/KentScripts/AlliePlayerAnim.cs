using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Move move;
    Jump jump;
    ObjectShooter shooter;

    Rigidbody2D rb;

    void Start()
    {
        // Get components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        move = GetComponent<Move>();
        jump = GetComponent<Jump>();
        shooter = GetComponentInChildren<ObjectShooter>();

        if (move == null) Debug.Log("I don't have a MOVE script!");
        if (jump == null) Debug.Log("I don't have a JUMP script!");
        if (shooter == null) Debug.Log("I don't have a GUN script!");
    }

    void Update()
    {
        // ---- RUNNING ----
        // Use Rigidbody2D horizontal velocity to drive running animation
        float horizontal = rb.linearVelocity.x;
        animator.SetFloat("animSpeed", Mathf.Abs(horizontal));

        // ---- JUMPING ----
        // Determine if player is in the air by checking vertical velocity
        bool isJumping = Mathf.Abs(rb.linearVelocity.y) > 0.01f;
        animator.SetBool("isJumping", isJumping);
    }
}
