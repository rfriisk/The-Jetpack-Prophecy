using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float horizontal = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * 5f, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if(horizontal > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
        }
        else if(horizontal < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }


}
