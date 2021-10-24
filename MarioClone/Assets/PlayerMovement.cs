using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    // private InputAction aimAction;
    // private InputAction shootAction;

    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityValue =  -9.81f;
    [SerializeField] public float playerSpeed;
    [SerializeField] private bool isJumping;
    [SerializeField] private float jumpTimeCounter;
    [SerializeField] private float jumpTime;

    private float turnSmoothTime;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];

        playerSpeed = 10f;
        gravityValue = -9.81f * 4f;
        jumpHeight = 2.5f;
        jumpTime = 1f;
        turnSmoothTime = 0.1f;
    }

    void Update()
    {
        // get input movement
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector2 camInput = lookAction.ReadValue<Vector2>();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            isJumping = false;
        }

        // old move option
        //Vector3 move = new Vector3(input.x, 0, input.y).normalized;

        // fix move relative to camera
        Vector3 movementX = Camera.main.transform.right * input.x;
        Vector3 movementZ = Camera.main.transform.forward * input.y;
        Vector3 move = movementX + movementZ;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        /*
        if (move.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(move * playerSpeed * Time.deltaTime);
        }
        */

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            
            if(jumpTimeCounter > 0 && isJumping == true) {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
                playerVelocity.y = 0f;
            }
        }
        

        // new jump
        /* if (!isJumping && groundedPlayer && jumpAction.triggered) {
            print("jumping");
        } */

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        //
    }
}
