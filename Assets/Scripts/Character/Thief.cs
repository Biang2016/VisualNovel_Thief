﻿using UnityEngine;

public class Thief : MonoBehaviour
{
    public float speed = 6.0F;
    private Vector2 moveDirection = Vector2.zero;
    public Animator Animator;
    public Rigidbody2D Rigidbody2D;
    public GameObject Umbrella;

    void Start()
    {
    }

    void Update()
    {
        if (CanMove)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            moveDirection = new Vector2(hor, ver);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            Rigidbody2D.velocity = moveDirection;
            Animator.SetBool("LeftRun", hor < 0);
            Animator.SetBool("RightRun", hor > 0);
        }
    }

    public bool CanMove = false;

    public void SetCanMove()
    {
        CanMove = true;
    }

    public void ForbidCanMove()
    {
        CanMove = false;
        Rigidbody2D.velocity = Vector2.zero;
    }

    private bool flying;

    public bool Flying
    {
        get { return flying; }
        set
        {
            flying = value;
            Umbrella.SetActive(value);
        }
    }
}