using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    private float currentSpeed;
    public float normalSpeed;
    public float boostedSpeed;

    [Header("Jump")]
    public float gravity;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;
    public float groundDistance;
    public float jumpHeight;

    private void Update()
    {
        Move();
        SpeedBoost();
        CheckIfGrounded();
        Jump();
        AdjustGravity();
    }

    private void AdjustGravity()
    {
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = boostedSpeed;
        else
            currentSpeed = normalSpeed;
    }

    private void Move()
    {
        float XMove = Input.GetAxis("Horizontal");
        float ZMove = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * XMove + transform.forward * ZMove;

        controller.Move(movement.normalized * currentSpeed * Time.deltaTime);
    }
}
