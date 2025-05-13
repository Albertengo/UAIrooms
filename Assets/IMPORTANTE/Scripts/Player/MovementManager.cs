using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementManager : MonoBehaviour
{
    // metodo para mover suavemente la camara,
    //vuelve a la normalidad despues
    //metodo para mover lentamente al jugador

    public CinemachineVirtualCamera virtualCamera;
    private CinemachinePOV pov;
    public CinemachineInputProvider inputProvider;
    public PlayerMovement playerMovement;

    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }


    public void ChangePlayerPostion(Transform newTransform, bool canMove)
    {
        playerMovement.canMove = canMove;
        player.transform.Translate(newTransform.position);
    }

    public void CameraRotation(bool blockCamera)
    {
        inputProvider.enabled = blockCamera;

        //Mathf.LerpAngle


    }
}
