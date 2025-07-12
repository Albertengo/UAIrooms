using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteractable : MonoBehaviour
{
    public bool isLocked = true;
    public UnityEvent onLockedInteract;
    public UnityEvent onUnlockedInteract;

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            if (isLocked)
            {
                onLockedInteract.Invoke(); //  puerta del salon
            }
            else
            {
                onUnlockedInteract.Invoke(); // puerta de bedelia
            }
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("puerta desbloqueada por evento");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
        Debug.Log("jugador esta cerca");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }

    public void DisableCollider()
    {
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;
    }

}
