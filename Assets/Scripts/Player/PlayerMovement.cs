using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [Header("CAMERA TRANSFORM")]
    [SerializeField] Transform cameraTransform;

    [Header("SPEED")]
    public float speed;
    private float initialSpeed;
    [SerializeField] float AddSpeed;

    [Header("JUMP")]
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce;
    int availableJumps = 1;




    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        initialSpeed = speed;
    }

    void Update()
    {
        Run();
        Jump();
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0f, direction.y);

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        Vector3 desiredMoveDirection = (forward * move.z + right * move.x).normalized;

        rb.velocity = desiredMoveDirection * speed + new Vector3(0, rb.velocity.y, 0);
    }


    void Run() //Hacer que la velocidad aumente y disminuya de forma gradual(?
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = initialSpeed + AddSpeed;
            Debug.Log(speed);
        }
        else
            speed = initialSpeed;
        Debug.Log(speed);
    }


    void Jump()
    {
        if (availableJumps == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            availableJumps = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            availableJumps = 1;
    }
}