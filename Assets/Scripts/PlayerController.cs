using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    public Transform cam;
    private Animator anim;

    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;
    private float dampTime = 0.02f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller=GetComponent<CharacterController>();
        playerInput=GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        Vector2 inputVector = playerInput.actions["Move"].ReadValue<Vector2>();
        float horizontal = inputVector.x;
        float vertical = inputVector.y;

        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation=Quaternion.Euler(0f,angle,0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            controller.Move(direction*playerSpeed*Time.deltaTime);
            anim.SetFloat("moveX",moveDirection.x,dampTime,Time.deltaTime);
            anim.SetFloat("moveZ",moveDirection.z,dampTime,Time.deltaTime);
        }
    }
}
