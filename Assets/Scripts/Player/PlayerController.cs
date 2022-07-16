using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //enum PlayerStates { Idle, Moving, Digging };
    //PlayerStates currentState;
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
    [SerializeField] private float digSpeed = 1;

    [SerializeField] private float digColdown;
    [SerializeField] private float digCountdown;
    [SerializeField] private float digDuration;
    [SerializeField] private float digCurrentTime;
    [SerializeField] private bool canDig = false;
    [SerializeField] private bool isDigging = false;

    [Space(10f)]
    [Header("-- Animator --")]
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //currentState = PlayerStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CancelDig();
        DigMechanic();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hor * movementSpeed, rb.velocity.y, ver * movementSpeed);
    }
    private void Movement()
    {
        // movement logic
        //transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

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

    private void DigMechanic()
    {   
        if(digCountdown >0 && !isDigging)
        {
            digCountdown -= Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(digCountdown <= 0 && canDig)
            {
                isDigging = true;
                digCountdown = digColdown;
                digCurrentTime = digDuration;
            }
        }
        if(isDigging)
        {
            digCurrentTime -= Time.deltaTime * digSpeed;
            if (digCurrentTime <= 0)
            {
                isDigging = false;
                Debug.Log("Finish Dig");
            }
        }
    }

    private void CancelDig()
    {
        if(isDigging && movementDirection != Vector3.zero)
        {
            isDigging = false;
            digCountdown = 0;
            digCurrentTime = digDuration;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            canDig = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canDig = false;
    }
}
