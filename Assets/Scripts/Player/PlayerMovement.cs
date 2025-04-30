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




    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        initialSpeed = speed;
    }

    void Update()
    {
        Run();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0f, direction.y);

        // Convertir el movimiento al espacio de la cámara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Aplanamos el movimiento en el plano XZ
        forward.y = 0f;
        right.y = 0f;

        Vector3 desiredMoveDirection = forward * move.z + right * move.x;
        desiredMoveDirection.Normalize();

        transform.position += desiredMoveDirection * speed * Time.deltaTime;
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = initialSpeed + AddSpeed;
        }
        else
            speed = initialSpeed;
    }
}
