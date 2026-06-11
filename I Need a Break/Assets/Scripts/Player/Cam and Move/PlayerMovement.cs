using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float sprintSpeed;

    [SerializeField] private float jumpForce;
    [SerializeField] private float airMult;
    private bool readyToJump;

    [SerializeField] private float descentForce;

    [SerializeField] private float groundedDrag;

    [SerializeField] private float playerHeight;
    //[SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [SerializeField] private KeyCode jump = KeyCode.Space;
    [SerializeField] private KeyCode sprint = KeyCode.LeftShift;
    [SerializeField] private KeyCode descend = KeyCode.F;
    [SerializeField] private KeyCode dash = KeyCode.R;

    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float dashForce;
    public bool canBoost;
    private float smallTime = 0;


    private Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private TMP_Text speedText;
    private float speedCounter;
    [SerializeField] private MoveState moveState;

    [SerializeField] private Animator anim;

    [SerializeField] private GameObject vignette;
    private Vignette vig;
    [SerializeField] private float maxValue;
    [SerializeField] private float addedValue;
    private float curValue;


    private enum MoveState
    {
        walking,sprint,inAir, idle
    }
    

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
        canBoost = true;
        UpdateIntensity(0);

        /*
        #if UNITY_WEBGL
            jumpForce = 7.5f;

            descentForce = 7f;

            walkSpeed = 10f;
            sprintSpeed = 15f; 

            airMult = 0.6f;
            groundedDrag = 1.1f;    
        #endif
        */
    }
    private void Update()
    {
        MyInput();
        SpeedControl();
        //StartDashCooldown();    

        if (isGrounded)
        {
            rb.drag = groundedDrag;
            ResetJump();
        }
        else
        {
            rb.drag = 0;
        }

        UpdateSpeedCounter();
        Effect();
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

        if(Input.GetKeyDown(descend) && !isGrounded)
        {
            FastDescent();
        }

        if (Input.GetKey(dash) && !isGrounded && canBoost)
        {
            StartCoroutine(DashReset());   
            Dash();

        }

        if (Input.GetKey(sprint) && isGrounded)
        {
            readyToJump = true;
            UpdateMoveState(MoveState.sprint);
        }
        else if (isGrounded)
        {
            readyToJump = true;
            UpdateMoveState(MoveState.walking);
        }
        else
        {
            UpdateMoveState(MoveState.idle);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMult, ForceMode.Force);
        }
    }

    private void FastDescent()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(-transform.up * descentForce, ForceMode.Impulse);
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
        moveDirection = orientation.forward /* *  verticalInput */ + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * dashForce, ForceMode.Impulse);
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
                UpdateAnim();
                break;
            case MoveState.sprint:
                moveState = MoveState.sprint;
                moveSpeed = sprintSpeed;
                speedCounter = sprintSpeed;
                UpdateAnim();
                
                break;
            case MoveState.inAir:
                moveState = MoveState.inAir;
                UpdateAnim();
                break;
            case MoveState.idle:
                moveState = MoveState.idle;
                UpdateAnim();
                break;

        }
    }

    private void UpdateAnim()
    {
        if (moveState == MoveState.walking)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }else if(moveState == MoveState.sprint)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", true);
        }
        else if(moveState == MoveState.idle)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
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

    public float GetWalkSpeed()
    {
        return walkSpeed;
    }

    public float GetSprintSpeed()
    {
        return sprintSpeed;
    }

    public void SetWalkSpeed(float newSpeed)
    {
        walkSpeed = newSpeed;
    }

    public void SetSprintSpeed(float newSpeed)
    {
        sprintSpeed = newSpeed;
    }
   
    IEnumerator DashReset()
    {
        Debug.Log("Dash Resetting");

        yield return new WaitForSeconds(1);

        canBoost = false;

        yield return new WaitForSeconds(3);

        canBoost = true;
    }


    private void Effect()
    {
        float minValue = 0;

        if (moveState == MoveState.sprint)
        {
            curValue += addedValue * Time.deltaTime;
            if (curValue >= maxValue)
            {
                curValue = maxValue;
            }
        }
        else
        {
            curValue = addedValue * Time.deltaTime;
            if (curValue <= minValue)
            {
                curValue = minValue;
            }
        }

        UpdateIntensity(curValue);
    }

    private void UpdateIntensity(float value)
    {
        vignette.GetComponent<PostProcessVolume>().weight = value;
    }
    
}
