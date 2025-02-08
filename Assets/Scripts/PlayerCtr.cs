using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerCtr : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Animator animatorController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] float playerSpeed =10f;
    [SerializeField] float rotationSpeed =5f;
    [SerializeField] float gravityValue = -9.81f;
    [SerializeField] float jumpHeight = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
        playerInput=GetComponent<PlayerInput>();
        animatorController=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f; // Reset velocity when on the ground
        }
        
        Move();
        Jump();

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    void Move()
    {
        Vector2 inputVector = playerInput.actions["Move"].ReadValue<Vector2>();

        if(inputVector != Vector2.zero)
        {
            controller.Move(transform.forward*inputVector.y*playerSpeed*Time.deltaTime);
        }

        if(inputVector.x !=0)
        {
            float rotationValue = rotationSpeed * inputVector.x;
            transform.Rotate(0, rotationValue*Time.deltaTime,0);
        }

        animatorController.SetFloat("moveZ", inputVector.y,0.02f,Time.deltaTime);
        animatorController.SetFloat("moveX",inputVector.x,0.02f,Time.deltaTime);
    }

    void Jump()
    {
        bool jumpPressed = playerInput.actions["Jump"].WasPressedThisFrame();

        if (jumpPressed && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue); // Apply jump force
            animatorController.SetTrigger("Jump"); // Play jump animation if available
            Debug.Log("Jump Pressed!");
        }
    }

}
