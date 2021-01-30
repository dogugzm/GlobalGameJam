﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    Animator anim;
    Collider2D coll;


    private enum State { IDLE, RUNNING, JUMPING, FALLING, HURT, CLIMB }
    [Header("States")]
    [SerializeField] private State state = State.IDLE;

    [Header("Movement")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float hurtForce = 10f;
    public float health = 100;


    [Header("Collectibles")]
    public int coinNumber = 0;

    [HideInInspector]
    public bool canClimb = false;


    #region SoundVariables
    [Header("Sounds")]
    [SerializeField] private AudioSource leftStepSound;
    [SerializeField] private AudioSource rightStepSound;
    [SerializeField] private AudioSource enemyDeathSound;
    [SerializeField] private AudioSource playerHurtSound;
    [SerializeField] private AudioSource collectedSound;
    [SerializeField] private AudioSource jump1Sound;
    [SerializeField] private AudioSource jump2Sound;
    [SerializeField] private AudioSource landSound; 
    #endregion


    
    private Vector2 currentVelocity;

    void Start()
    { 
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    
    void Update()
    {
         if (state != State.HURT)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);
        //Debug.Log((int)rigidbody2D.velocity.x);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collectedSound.Play();
            coinNumber++;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (state == State.FALLING)
            {
                enemyDeathSound.Play();
                Destroy(collision.gameObject);
                Jump();
            }
            else
            {
                state = State.HURT;
                if (this.transform.position.x < collision.gameObject.transform.position.x)
                {
                    playerHurtSound.Play();
                    rigidbody2D.velocity = new Vector2(-hurtForce, rigidbody2D.velocity.y);
                    health -= 50;
                }
                else
                {
                    playerHurtSound.Play();
                    rigidbody2D.velocity = new Vector2(hurtForce, rigidbody2D.velocity.y);
                    health -= 50;
                }
            }

        }
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        float velocity = hDirection * speed;

        if (canClimb && Mathf.Abs(Input.GetAxis("Vertical")) > .1f)
        {
            state = State.CLIMB;
        }
        if (hDirection < 0)
        {
            rigidbody2D.velocity = Vector2.SmoothDamp( rigidbody2D.velocity,new Vector2(velocity , rigidbody2D.velocity.y), ref currentVelocity,0.02f);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, new Vector2(velocity, rigidbody2D.velocity.y), ref currentVelocity, 0.02f);

            //rigidbody2D.velocity = new Vector2(velocity , rigidbody2D.velocity.y);
            transform.localScale = new Vector2(+1, 1);
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(groundLayer))
        {
            Jump();
        }
    }
    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        PlayJumpSound();
        state = State.JUMPING;
    }
    private void AnimationState()
    {
        if (state == State.CLIMB)
        {
            if (!canClimb)
            {
                state = State.IDLE;
            }
        }
        else if (state == State.JUMPING)
        {
            if (rigidbody2D.velocity.y < 0.1f)
            {
                state = State.FALLING;
            }
        }

        else if (state == State.FALLING)
        {
            if (coll.IsTouchingLayers(groundLayer))
            {
                PlayLandSound();
                state = State.IDLE;
            }
        }
        else if (state == State.HURT)
        {
            if (Mathf.Abs(rigidbody2D.velocity.x) < .1f)
            {
                state = State.IDLE;
            }
        }

        else if (Mathf.Abs(rigidbody2D.velocity.x) > 2f)
        {
            state = State.RUNNING;
        }

        else
        {
            state = State.IDLE;
        }
    }


    #region Sounds
    public void PlayLeftStepSound()
    {
        leftStepSound.Play();
    }
    public void PlayRightStepSound()
    {
        rightStepSound.Play();
    }
    public void PlayJumpSound()
    {
        float num = UnityEngine.Random.Range(1, 10);
        if (num <= 5)
        {
            jump1Sound.Play();
        }
        else
        {
            jump2Sound.Play();
        }
    }
    public void PlayLandSound()
    {
        landSound.Play();
    }
} 
#endregion
