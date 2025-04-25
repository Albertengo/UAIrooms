using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  

    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] float Speed;
    [SerializeField] Transform cameraTransform;
    private Vector3 WhereMyCameraIsLocated;
    private Vector3 WhatMyCameraIsLookingAt;

    void Start()
    {
       playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        HideMouse();
    }

    void Update()
    {
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
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * move.z + right * move.x;
        transform.position += desiredMoveDirection * Speed * Time.deltaTime;

        /* este codigo hizo q el player como q SALTE a una posicion especifica, es re raro...
        Vector3 move = new Vector3(direction.x, 0f, direction.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        transform.position = move * Speed; //Time.deltaTime * Speed;
        */
    }

    void HideMouse()
    {
        Cursor.visible = false; // Hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}
