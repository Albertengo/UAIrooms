using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour
{
    public Collider doorCollider;
    //public float delayToDisable = 1.5f;

    private bool isNear = false;
    public bool doorOpened = false;
    public bool requiresKey = false;

    void Update()
    {
        if (isNear && !doorOpened && Input.GetKeyDown(KeyCode.F))
        {
            doorOpened = true;
            DisableDoorCollider();

        }
    }

    private void DisableDoorCollider()
    {
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
            Debug.Log("Puerta desbloqueada, collider desactivado");
        }
        else
        {
            Debug.LogWarning("No se asignó el collider de la puerta");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
