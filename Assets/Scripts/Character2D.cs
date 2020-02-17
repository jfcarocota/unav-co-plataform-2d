﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UNAV2DUtils.GameplaySystem;

public class Character2D : MonoBehaviour
{
    [SerializeField, Range(0.1f, 7f)]
    protected float moveSpeed = 3f;
    [SerializeField, Range(0.1f, 10f)]
    protected float jumpForce = 7f;

    protected SpriteRenderer spr;

    protected Animator anim; 

    protected Rigidbody2D rb2d;

    [SerializeField]
    protected Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)]
    protected float rayDistance = 2f;
    [SerializeField]
    protected LayerMask groundLayer;
    [SerializeField]
    protected float maxVel;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected bool FlipSprite
    {
        get => GameplaySystem.Axis.x > 0 ? false : GameplaySystem.Axis.x < 0 ? true : spr.flipX;
    }

    protected bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }

    protected bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

}
