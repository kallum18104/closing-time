using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;

    public HeadBob bob;

    float rbDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    float movementMultiplier = 10f;

    public Vector3 moveDirection;

    public Rigidbody rb;

    Camera cam;

    public bool running;


    float dynamicFOVTime = 1f;

    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;

    public AudioSource Source;
    public AudioSource SourceRun;


    public GameObject Menu;

    public PlayerLook look;
    public PlayerMovement move;
    public Lean leaning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        cam = GetComponentInChildren<Camera>();

        playerCol = GetComponentInChildren<CapsuleCollider>();
        originalHeight = playerCol.height;

    }

    private void Update()
    {

        if (running)
        {
            SourceRun.enabled = true;
            Source.enabled = false;



        }
        else
        {
            Source.enabled = true;
            SourceRun.enabled = false;



        }
        ControlDrag();
        MyInput();

        if (Input.GetKey(KeyCode.G))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 5, dynamicFOVTime * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, dynamicFOVTime * Time.deltaTime);

        }

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {

            if (running)
            {
                SourceRun.enabled = true;
                Source.enabled = false;



            }
            else
            {
                Source.enabled = true;
                SourceRun.enabled = false;



            }
        }
        else
        {
            //   run.enabled = false;
            Source.enabled = false;
        }


        if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.instance.canRun)
        {
            moveSpeed = 9f;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80, dynamicFOVTime * Time.deltaTime);
            bob.walkingBobbingSpeed = 24f;
            bob.bobbingAmount = 0.3f;
            running = true;


        }
        else
        {
            moveSpeed = 6f;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, dynamicFOVTime * Time.deltaTime);
            bob.walkingBobbingSpeed = 12f;
            bob.bobbingAmount = 0.1f;
            running = false;


        }

        if (Input.GetKey(KeyCode.C))
        {
            playerCol.height = reducedHeight;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 45, dynamicFOVTime * Time.deltaTime);
            StaminaBar.instance.canRun = false;
            moveSpeed = 3f;
            bob.walkingBobbingSpeed = 6f;
            bob.bobbingAmount = 0.05f;


        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            playerCol.height = originalHeight;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, dynamicFOVTime * Time.deltaTime);
            StaminaBar.instance.canRun = true;
            moveSpeed = 6f;
            bob.walkingBobbingSpeed = 12f;
            bob.bobbingAmount = 0.1f;


        }
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if (running)
        {
            StaminaBar.instance.currentStamina -= 0.5f;
        }
        else
        {
            if (StaminaBar.instance.currentStamina < StaminaBar.instance.maxStamina)
            {
                StaminaBar.instance.currentStamina += 0.5f;
            }
        }
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }


    public void Dead()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        look.enabled = false;
        move.enabled = false;
        leaning.enabled = false;
        move.Source.enabled = false;
        move.SourceRun.enabled = false;
    }

}






