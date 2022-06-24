using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatedPlayerMovement : MonoBehaviour
{

    
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpGracePeriod;

    
    private float walkSpeed = 7.5f;
    private float runSpeed = 15f;
    private float speed;
    private Animator animator;
    private float ySpeed;
    private float originalStepOffset;
    private CharacterController characterController;
    private float? jumpButtonPressedTime;
    private float? lastGroundedTime;

    [SerializeField] private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = movementDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded){
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump")){
            jumpButtonPressedTime = Time.time;
            animator.SetBool("jumping", true);
        }else{
            animator.SetBool("jumping", false);
        }

        if(Time.time - lastGroundedTime <= jumpGracePeriod){

            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if(Time.time - jumpButtonPressedTime <= jumpGracePeriod){
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        } else{
            characterController.stepOffset = 0;
        }

        if(Input.GetButton("Sprint") && characterController.isGrounded){
            animator.SetBool("running", true);
            speed = runSpeed;
        } else {
           animator.SetBool("running", false);
           speed = walkSpeed; 
        }
        
        // transform.Translate(movementDirection * magnitude * speed * Time.deltaTime, Space.World);
        Vector3 velocity = movementDirection * speed* magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero){
            animator.SetBool("moving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        } else{
            animator.SetBool("moving", false);
        }
    }

    private void onApplicationFocus(bool focus){
        if(focus){
            Cursor.lockState = CursorLockMode.Locked;
        } else{
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
