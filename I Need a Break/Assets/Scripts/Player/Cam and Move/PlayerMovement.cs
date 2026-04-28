using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    [SerializeField] private float jumpForce;
    //[SerializeField] private float jumpCooldown;
    [SerializeField] private float airMult;
    private bool readyToJump;

    [SerializeField] private float groundedDrag;

    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [SerializeField] private KeyCode jump = KeyCode.Space;
    [SerializeField] private KeyCode sprint = KeyCode.LeftShift;
    // [SerializeField] private KeyCode descend = KeyCode.F;
    [SerializeField] private KeyCode dash = KeyCode.R;

    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private TMP_Text speedText;
    private float speedCounter;
    [SerializeField] private MoveState moveState;

    
    private enum MoveState
    {
        walking,sprint,inAir
    }
    

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    private void Update()
    {
        //CheckIfGrounded();
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if(isGrounded)
        {
            rb.drag = groundedDrag;
            ResetJump();
        }
        else
        {
            rb.drag = 0;
        }

        UpdateSpeedCounter();

        Debug.Log(isGrounded);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jump) && readyToJump && isGrounded)
        {
            readyToJump = false;

            Jump();
        }

        if(Input.GetKey(dash))
        {
            Dash();
        }

        if (Input.GetKey(sprint) && isGrounded)
        {
            readyToJump = true;
            UpdateMoveState(MoveState.sprint);
        }
        else if(isGrounded)
        {
            readyToJump = true;
            UpdateMoveState(MoveState.walking);
        }
        else
        {
            UpdateMoveState(MoveState.inAir);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }else if(!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMult, ForceMode.Force);
        }
    }

    private void FastDescent()
    {

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Dash()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * 6f, ForceMode.Impulse);
    }
    
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void UpdateSpeedCounter()
    {
        speedText.text = "Speed: " + speedCounter;
    }

    private void UpdateMoveState(MoveState state)
    {
        switch(state)
        {
            case MoveState.walking:
                moveState = MoveState.walking;
                moveSpeed = walkSpeed;
                speedCounter = walkSpeed;
                break;
            case MoveState.sprint:
                moveState = MoveState.sprint;
                moveSpeed = sprintSpeed;
                speedCounter = sprintSpeed;
                break;
            case MoveState.inAir:
                moveState = MoveState.inAir;
                break;

        }
    }

    private void CheckIfGrounded()
    {
        /*
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, playerHeight * 0.5f + 0.2f, whatIsGround);

        Vector3 originRay = transform.position;
        Vector3 direction = Vector3.down;

        Ray thingRay = new Ray(originRay, direction);

        Debug.DrawRay(thingRay.origin, thingRay.direction, Color.red);
        */

        /*
        if (Physics.Raycast(transform.position, -Vector3.up, 0.1f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        */

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Jumpable")
        {
            isGrounded = false;
        }
    }


}
