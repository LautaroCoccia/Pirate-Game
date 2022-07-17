using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //enum PlayerStates { Idle, Moving, Digging };
    //PlayerStates currentState;
    public static Action SpawnChest;
    public static Action OnDie;
    private Rigidbody rb;
    [Space(10f)]
    [Header("-- Movement --")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float moveSpeedMultiplier = 1;
    [SerializeField] private float rotationSpeed;
    private float hor;
    private float ver;
    private Vector3 movementDirection;

    [Space(10f)]
    [Header("-- Dig --")]
    [SerializeField] private float animatorNormalSpeed = 1;
    [SerializeField] private float animatorDigSpeed = 1;

    [SerializeField] private float digColdown;
    [SerializeField] private float digCountdown;
    [SerializeField] private float digDuration;
    [SerializeField] private float digCurrentTime;
    [SerializeField] private bool canDig = false;
    [SerializeField] private bool isDigging = false;

    [Space(10f)]
    [Header("-- Animator --")]
    [SerializeField] private PlayerAnimController anim;

    bool isShieldActive = true;
    [SerializeField] GameObject shieldObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimController>();
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
        rb.velocity = new Vector3(movementDirection.x, rb.velocity.y, movementDirection.z);
    }
    private void Movement()
    {
        //movement logic
        //transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hor, 0, ver);
        movementDirection.Normalize();
        anim.SetActiveMovementAnim((int)movementDirection.magnitude);
        movementDirection = movementDirection * movementSpeed * moveSpeedMultiplier;
        // rotation logic
        if (movementDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    private void DigMechanic()
    {   
        if(digCountdown > 0 && !isDigging)
        {
            digCountdown -= Time.deltaTime * animatorDigSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(digCountdown <= 0 && canDig)
            {
                isDigging = true;
                anim.SetActiveDigAnimation(isDigging, animatorDigSpeed);
                digCountdown = digColdown;
                digCurrentTime = digDuration;
            }
        }
        if(isDigging)
        {
            digCurrentTime -= Time.deltaTime * animatorDigSpeed;
            if (digCurrentTime <= 0)
            {
                isDigging = false;
                anim.SetActiveDigAnimation(isDigging, animatorDigSpeed);
                SpawnChest?.Invoke();
            }
        }
    }

    private void CancelDig()
    {
        if(isDigging && movementDirection != Vector3.zero)
        {
            isDigging = false;
            anim.SetActiveDigAnimation(isDigging, animatorNormalSpeed);
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

    public void SetDigSpeed(float newSpeed)
    {
        animatorDigSpeed = newSpeed;
    }

    public void SetMovementSpeed(float newSpeed)
    {
        moveSpeedMultiplier = newSpeed;
    }
    public void SetActiveShield(bool isActive)
    {
        if (!isActive && !isShieldActive)
        {
            OnDie?.Invoke();
            Debug.Log("DIe");
        }
        else
        {
            isShieldActive = isActive;
            shieldObject.SetActive(isShieldActive);
        }
    }
}
