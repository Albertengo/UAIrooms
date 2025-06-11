using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [Header("SCRIPTS")]
    public CinemachineInputProvider inputProvider;
    public PlayerMovement playerMovement;

    [Header("CAMERAS")]
    [SerializeField] Camera storeCamera;
    [SerializeField] GameObject mainCamera;

    GameObject player;
    [SerializeField] float speed;


    private void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        storeCamera.enabled = false;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, storeCamera.transform.position) > 0.1f && !playerMovement.canMove)
            player.transform.position = Vector3.Lerp(player.transform.position,storeCamera.transform.position, Time.deltaTime * speed);
    }


    public void ChangePlayerPostion(bool canMove)
    {
        playerMovement.canMove = canMove;
    }

    public void CameraRotation(bool canChangeCamera)
    {
        if (canChangeCamera)
        {
            ChangeCameraPriority(10, 0, true);
        }
        else
            ChangeCameraPriority(0, 10, false);
    }

    void ChangeCameraPriority(int mainCameraPriority, int storeCameraPriority, bool blockCamera)
    {
        mainCamera.GetComponent<CinemachineVirtualCamera>().Priority = mainCameraPriority;
        storeCamera.GetComponent<CinemachineVirtualCamera>().Priority = storeCameraPriority;
        inputProvider.enabled = blockCamera;
    }
}
