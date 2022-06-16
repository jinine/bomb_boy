using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatedPlayerMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpGracePeriod;

    private float ySpeed;
    private float originalStepOffset;
    private CharacterController characterController;
    private float? jumpButtonPressedTime;
    private float? lastGroundedTime;

    // Start is called before the first frame update
    void Start()
    {
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
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded){
            lastGroundedTime = Time.time;
        }

        if(Input.GetButtonDown("Jump")){
            jumpButtonPressedTime = Time.time;
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

        // transform.Translate(movementDirection * magnitude * speed * Time.deltaTime, Space.World);
        Vector3 velocity = movementDirection * speed* magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
