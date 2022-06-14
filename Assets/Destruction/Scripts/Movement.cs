using System.Collections;
using UnityEngine;
using System;

public class Movement : MonoBehaviour, ICollidable
{
    public static Action<float, float, float> IsPushing;
    
    [Space(10f)]
    [Header("-- Movement --")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [Space(10f)]
    [Header("-- Dig --")]
    [Space(20f)]
    [Range(0.01f, 1f)]
    [SerializeField] private float digCooldown;
    [SerializeField] private float digCountdown;
    [SerializeField] private bool canDig = false;
    [SerializeField] private bool isDigging = false;
    [Space(10f)]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject trigger;
    private bool canJump = false;
    
    private float hor;
    private float ver;
    private Vector3 movementDirection;

    private Rigidbody rb;

    // ----------------------

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();

        PlayerDigLogic();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TARO: hace la logica para que esto se haga cuando choque con un suelo.
        canJump = true;
        //COMENTARIO - TOMAS: No me parece muy copada la forma en la que se chequea la colision despues de un salto usando el "OnCollisionEnter"
    }

    private void PlayerMovement()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hor, 0, ver);
        movementDirection.Normalize();

        anim.SetInteger("MovementVector", (int)movementDirection.magnitude);
        if((int)movementDirection.magnitude > 0)
        {
            anim.SetBool("Dig", false);
            digCountdown = 0;
        }
        rb.velocity = new Vector3(hor * movementSpeed, rb.velocity.y, ver * movementSpeed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    private void PlayerDigLogic()
    {
        if (digCountdown >= 0)
        {
            digCountdown -= Time.deltaTime;
        }
        else if (digCountdown < 0 && isDigging)
        {
            isDigging = false;
            canDig = false;
            anim.SetBool("Dig", false);
            if(trigger!=null)
            {
                trigger.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (digCountdown <= 0 && canDig)
            {
                isDigging = true;
                anim.SetBool("Dig", true);
                digCountdown = digCooldown;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        trigger = other.gameObject;
        canDig = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canDig = false;
    }
}
