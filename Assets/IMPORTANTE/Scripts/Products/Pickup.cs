using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public GameObject keyObject;
    public UnityEvent onKeyPickup;

    private bool isPlayerNear = false;
    public bool hasKey = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            onKeyPickup.Invoke(); // Evento al recoger llave
            keyObject.SetActive(false); // Ocultar la llave
            hasKey = true;
            Debug.Log("Llave recogida.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}