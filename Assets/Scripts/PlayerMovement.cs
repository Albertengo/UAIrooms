using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //NOTA: intent� hacer el codigo sin seguir mucho el video q mand� x el canal de programaci�n y no me funcion�,
    // capaz tendriamos q ver de hacerlo m�s parecido o ver otra manera?? es medio tarde asi q lo dejo ac� je -ori

    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] float Speed;
    [SerializeField] Transform cameraTransform;

    void Start()
    {
       playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
       Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
        
        /* este codigo hizo q el player como q SALTE a una posicion especifica, es re raro...
        Vector3 move = new Vector3(direction.x, 0f, direction.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        transform.position = move * Speed; //Time.deltaTime * Speed;
        */
    }
}
