using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Fuel fuel;
    private MapGenerator mapGenerator;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float horizontal = 0f;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private enum MovementState { idle, running, jetpack }
    
    [SerializeField]
    private AudioSource jetPackSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        // Get the Fuel component from the player character
        fuel = GetComponent<Fuel>();

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (fuel.currentFuel > 0)
            {
                fuel.UseJetPack();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jetPackSound.Play();
            }
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jetpack;
        }

        anim.SetInteger("state", (int)state);

    }

}
