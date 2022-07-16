using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [Space(10f)]
    [Header("-- Movement --")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private float hor;
    private float ver;
    private Vector3 movementDirection;

    [Space(10f)]
    [Header("-- Dig --")]
    [SerializeField] private float digColddown;
    [SerializeField] private float digCountdown;
    [Space(10f)]
    [Header("-- Animator --")]
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hor * movementSpeed, rb.velocity.y, ver * movementSpeed);
    }
    private void Movement()
    {
        // movement logic
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hor, 0, ver);
        movementDirection.Normalize();

        // rotation logic
        if (movementDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }
}
