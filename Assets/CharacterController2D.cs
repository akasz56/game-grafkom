using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private AudioSource footstep;
    [SerializeField] float speed = 1f;
    [SerializeField] float sprint = 1.5f;

    Vector2 motionVector;

    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
            );
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
            ).normalized;

            animator.SetFloat("lasthorizontal", horizontal);
            animator.SetFloat("lastvertical", vertical);

            //footstep.Play();
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey("left shift"))
        {
            rigidbody2d.velocity = motionVector * speed * sprint;
        }
        else
        {
            rigidbody2d.velocity = motionVector * speed;
        }

    }
}
