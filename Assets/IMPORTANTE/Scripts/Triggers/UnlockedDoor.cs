using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour
{
    //public Animator doorAnimator;
    public float delayToDisable = 1.5f; 
    private bool isNear = false;
    private bool doorOpened = false;

    void Update()
    {
        if (isNear && !doorOpened && Input.GetKeyDown(KeyCode.F))
        {
        /*    doorAnimator.SetTrigger("Open")*/;
            doorOpened = true;
            Invoke("DisableDoor", delayToDisable);

        }
    }

    private void DisableDoor()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isNear = false;
    }
}
